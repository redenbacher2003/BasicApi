using System;

public class BO
{
	public class BillType()
	{
		public int id { get; set; }
		public float DefaultAmount { get; set; }
		public string DueDateType { get; set; }
		public int DueDay { get; set; }	
	    public DateTime Added { get; set;}
	    public string AddedBy { get; set; }
	    public DateTime Deleted { get; set;}
		public string DeletedBy { get; set; }
	}

}
