using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DSIP_.Models
{
    [BsonIgnoreExtraElements]
    public class Item
    { 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("Name")]
        public string itemName { get; set; }

        public float value { get; set; }

        public string itemMaster { get; set; }
    }
}

//5d7672457fc6dd4730c53de5
/* mongoimport -h theisubdsip.documents.azure.com:10255 \
 -d theisubdsip -c example -u theisubdsip \
  -p tPl80uOKILxJwdIYZA34YdJ5X0IrUzOVtJMjihZPDCMNORmcsKNLvX23d7A9Oz1JsuKAuD7vact6ejg4hf4cyg== \
  --ssl --jsonArray  --file db.json */
