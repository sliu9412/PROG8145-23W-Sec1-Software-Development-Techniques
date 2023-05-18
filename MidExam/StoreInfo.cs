public class StoreInfo: IStoreInfo {
    public string? store_name {get; set;}
    public string? store_address  {get; set;}
    public string? store_owner_first_name  {get; set;}
    public string? store_owner_last_name  {get; set;}
    public string ShowStoreInformation() {
        return $"============\nWelcome to {store_name}!\nWe're located at {store_address}\nThe Owner is {store_owner_first_name} {store_owner_last_name}\n============";
    }
}