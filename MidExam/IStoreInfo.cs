interface IStoreInfo {
    public string? store_name {get; set;}
    public string? store_address  {get; set;}
    public string? store_owner_first_name  {get; set;}
    public string? store_owner_last_name  {get; set;}
    // return the string of store infomation
    public string ShowStoreInformation();
}