using Ciurca_Radu_Lab7.Models;

namespace Ciurca_Radu_Lab7;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
async void OnSaveButtonClicked(object sender, EventArgs e)
{
    var slist = (ShopList)BindingContext;
    slist.Date = DateTime.UtcNow;
    Shop selectedShop = (ShopPicker.SelectedItem as Shop);
    slist.ShopID = selectedShop.ID;
    await App.Database.SaveShopListAsync(slist);
    await Navigation.PopAsync();
}
async void OnDeleteButtonClicked(object sender, EventArgs e)
{
    var slist = (ShopList)BindingContext;
    await App.Database.DeleteShopListAsync(slist);
    await Navigation.PopAsync();
}
    async void OnDeleteButtonItemClicked(object sender, EventArgs e)
    {
        var currentShopList = BindingContext as ShopList;
        var selectedProduct = listView.SelectedItem as Product;

        if (selectedProduct != null && currentShopList != null)
        {
            await App.Database.DeleteProductFromShopListAsync(selectedProduct.ID, currentShopList.ID);

            listView.ItemsSource = await App.Database.GetListProductsAsync(currentShopList.ID);

            listView.SelectedItem = null;
        }
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
{
    await Navigation.PushAsync(new ProductPage((ShopList)
   this.BindingContext)
    {
        BindingContext = new Product()
    });

}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetShopsAsync();
        ShopPicker.ItemsSource = (System.Collections.IList)items;
        ShopPicker.ItemDisplayBinding = new Binding("ShopDetails");
        var shopl = (ShopList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }


}