
using Newtonsoft.Json.Linq;

using System;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using Newtonsoft.Json.Schema;

//Path File for main Schema for local 
using (StreamReader file = File.OpenText(@"C:Path File"))
using (JsonTextReader reader = new JsonTextReader(file))
{
    JSchemaUrlResolver resolver = new JSchemaUrlResolver();

    JSchema schema2 = JSchema.Load(reader, new JSchemaReaderSettings
    {
        Resolver = resolver,
        BaseUri = new Uri(@"C:Path File")
    });
    JObject patient = JObject.Parse(@"{
    'id':1,
    'name':'alper',
    'gender':'male',
    'phone':'(555)555-5555',
    'adress':{'adress':'asda','adress2':'asd'}
}");
    Console.WriteLine(schema2);
    var valid = patient.IsValid(schema2, out IList<string> messages);
    Console.WriteLine(valid);
    foreach (var message in messages)
    {
        Console.WriteLine(message);
    }
}


