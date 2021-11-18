using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace CustomData_Database_Test.Models
{
	public class Animal : BaseModel
	{

		public int? RecordId { get; set; }

		public string Name { get; set; }

		public string SqlTableName { get { return "Animal"; } }

		public Animal()
        {					
        }

		change to this.
		public void Data_Insert(Animal _DataObject)
		{
			Animal _Animal = new Animal();

			CustomData_DatabaseEngine.DBContext.Data_Insert(_DataObject);

			this.RecordId = 121;
			this.Name = "Dave Hassellhoff";

			this.Data_Transaction_Status = true;
			this.Data_Transaction_Message = "Data Select was successful.";

		}

		public void Data_Update(Animal _DataObject)
		{
			Animal _Animal = new Animal();

			CustomData_DatabaseEngine.DBContext.Data_Update(_DataObject);

			this.RecordId = 121;
			this.Name = "Dave Hassellhoff";

			this.Data_Transaction_Status = true;
			this.Data_Transaction_Message = "Data Select was successful.";

		}


		public void Data_Select(Animal _DataObject)
		{
			Animal _Animal = new Animal();

			CustomData_DatabaseEngine.DBContext.Data_Select(_DataObject);

			this.RecordId = 121;
			this.Name = "Dave Hassellhoff";

			this.Data_Transaction_Status = true;
			this.Data_Transaction_Message = "Data Select was successful.";

		}
	}
}