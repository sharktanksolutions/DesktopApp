using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace supershop
{
    class OrderHeaders
    {
        private int _orderId;
        private int _employeeID;
        private string _stationID;
        private string _orderType;
        private string _customerID;
        private double _deliveryCharge;
        private double _deliveryComp;
        private int _driverEmployeeID;
        private string _driverDepartureTime;
        private string _driverArrivalTime;
        private string _onHoldUntilTime;
        private double _salesTaxRate;
        private int _discountID;
        private double _discountAmount;
        private double _discountBasis;
        private bool _discountTaxable;
        private string _orderStatus;
        private double _amountDue;
        private bool _kitchen1AlreadyPrinted;
        private bool _kitchen2AlreadyPrinted;
        private bool _kitchen3AlreadyPrinted;
        private bool _packagerAlreadyPrinted;
        private double _subTotal;
        private string _rowVer;
        private string _storeNumber;

        public int OrderId { get => _orderId; set => _orderId = value; }
        public int EmployeeID { get => _employeeID; set => _employeeID = value; }
        public string StationID { get => _stationID; set => _stationID = value; }
        public string OrderType { get => _orderType; set => _orderType = value; }
        public string CustomerID { get => _customerID; set => _customerID = value; }
        public double DeliveryCharge { get => _deliveryCharge; set => _deliveryCharge = value; }
        public double DeliveryComp { get => _deliveryComp; set => _deliveryComp = value; }
        public int DriverEmployeeID { get => _driverEmployeeID; set => _driverEmployeeID = value; }
        public string DriverDepartureTime { get => _driverDepartureTime; set => _driverDepartureTime = value; }
        public string DriverArrivalTime { get => _driverArrivalTime; set => _driverArrivalTime = value; }
        public string OnHoldUntilTime { get => _onHoldUntilTime; set => _onHoldUntilTime = value; }
        public double SalesTaxRate { get => _salesTaxRate; set => _salesTaxRate = value; }
        public int DiscountID { get => _discountID; set => _discountID = value; }
        public double DiscountAmount { get => _discountAmount; set => _discountAmount = value; }
        public double DiscountBasis { get => _discountBasis; set => _discountBasis = value; }
        public bool DiscountTaxable { get => _discountTaxable; set => _discountTaxable = value; }
        public string OrderStatus { get => _orderStatus; set => _orderStatus = value; }
        public double AmountDue { get => _amountDue; set => _amountDue = value; }
        public bool Kitchen1AlreadyPrinted { get => _kitchen1AlreadyPrinted; set => _kitchen1AlreadyPrinted = value; }
        public bool Kitchen2AlreadyPrinted { get => _kitchen2AlreadyPrinted; set => _kitchen2AlreadyPrinted = value; }
        public bool Kitchen3AlreadyPrinted { get => _kitchen3AlreadyPrinted; set => _kitchen3AlreadyPrinted = value; }
        public bool PackagerAlreadyPrinted { get => _packagerAlreadyPrinted; set => _packagerAlreadyPrinted = value; }
        public double SubTotal { get => _subTotal; set => _subTotal = value; }
        public string RowVer { get => _rowVer; set => _rowVer = value; }
        public string StoreNumber { get => _storeNumber; set => _storeNumber = value; }
    }
}
