namespace Domain.Constants;

public static class ProductMessage
{
    public const string ProductNameRepeated = "No puede crear producto con el mismo nombre.";
    public const string ProductNameRepeatedUpdate = "No puede actualizar producto con el mismo nombre.";
    public const string ProductNotFound = "Producto no encontrado";
    public const string ProductForSale = "No se puede eliminar el producto porque está asociado a una venta";
}
