using System;

public class OrderHeaders
{
	public OrderHeaders()
	{
   
    private int _orderId;
    private int _employeeID;

    public int OrderId { get => _orderId; set => _orderId = value; }
    public int EmployeeID { get => _employeeID; set => _employeeID = value; }
}
}
