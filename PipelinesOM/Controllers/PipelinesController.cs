using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PipelinesOM.Models;
using System.Reflection;
using System.IO;
using Microsoft.CSharp.RuntimeBinder;
using System.Xml;

namespace PipelinesOM.Controllers
{
    public class PipelinesController : ApiController
    {

        public IHttpActionResult GetPipeline(string assembly)
        {
            string ass = assembly.Substring(assembly.IndexOf(',') + 1).TrimStart();
            string ass_class = assembly.Substring(0, assembly.IndexOf(',')).TrimEnd();

            Assembly pipeline_ass = null;

            try
            {
                pipeline_ass = Assembly.Load(ass);
            }
            catch (FileNotFoundException)
            {

                return NotFound();
            }
            

            Type type = pipeline_ass.GetType(ass_class);

            if (type == null)
                return NotFound();

            dynamic dyn_pipeline = Activator.CreateInstance(type);

            string pipeline_data = null;

            try
            {
                pipeline_data = dyn_pipeline.XmlContent;
            }
            catch (RuntimeBinderException)
            {

                return NotFound();
            }

            Pipeline pipeline = new Pipeline();

            //create Pipeline object
            using (XmlReader reader = XmlReader.Create(new StringReader(pipeline_data)))
            {
                

                while (reader.Read())
                {


                    if (reader.LocalName == "Stage" && reader.IsStartElement())
                    {
                        Stage stage = new Stage();

                        reader.ReadToFollowing("PolicyFileStage");
                        reader.MoveToAttribute("stageId");

                        stage.CategoryId = reader.Value;

                        reader.ReadToFollowing("Components");

                        

                        while (reader.ReadToDescendant("Component"))
                        {
                            Component component = new Component();

                            
                            reader.ReadToFollowing("Name");
                            string comp_name = reader.ReadElementContentAsString();
                            component.Name = comp_name.Substring(0, comp_name.IndexOf(',')).TrimEnd();

                            reader.ReadToFollowing("Properties");

                            XmlReader properties = reader.ReadSubtree();

                            while (properties.ReadToFollowing("Property"))
                            {
                                Property property = new Property();

                                reader.MoveToAttribute("Name");
                                property.Name = reader.Value;

                                reader.ReadToFollowing("Value");
                                
                                property.Value = reader.ReadElementContentAsString();

                                component.Properties.Add(property);

                            }

                            stage.Components.Add(component);
                        }

                        pipeline.Stages.Add(stage);
                    }
                }
            }


            return Ok(pipeline);
        }
    }
}
