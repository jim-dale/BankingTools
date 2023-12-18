﻿namespace OfxNet;

using System.ComponentModel;

public enum OfxAccountType
{
    NotSet,
    [Description("Checking")]
    CHECKING,
    [Description("Savings")]
    SAVINGS,
    [Description("Money Market")]
    MONEYMRKT,
    [Description("Line of credit")]
    CREDITLINE,
    [Description("Certificate of Deposit")]
    CD,
}
