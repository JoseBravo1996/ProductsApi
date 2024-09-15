using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entityBuilder)
    {
        entityBuilder.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD0A90984D");

        entityBuilder.ToTable("Product");

        entityBuilder.Property(e => e.ProductId).HasDefaultValueSql("(newid())");

        entityBuilder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
        entityBuilder.Property(e => e.Price).HasColumnType("decimal(18, 2)");

        entityBuilder.HasOne(d => d.Category).WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entityBuilder.HasData(GetInitialProducts());
    }

    private static readonly List<Product> _products = [
        new()
        {
            Name = "Aire Acondicionado Bgh 2967 Frigorías - 3450 Watts- Frio/calor",
            Description = "El aire acondicionado BS35WCCR de BGH es la solución perfecta para mantener tu hogar fresco y confortable durante los días calurosos de verano. Con su potente capacidad de enfriamiento, este equipo te brinda un ambiente agradable en cada rincón de tu casa.",
            Price = 639999M,
            CategoryId = 1,
            Discount = 3,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/812387-800-auto?v=638440520410670000&width=800&height=auto&aspect=true"
        },
        new()
        {
            Name = "Jarra Eléctrica Inoxidable Nex Ka010oi20 1,8 L",
            Description = "La jarra eléctrica Nex Inox KA010OI20 es la compañera perfecta para tus momentos de relajación y disfrute en casa.",
            Price = 20159M,
            CategoryId = 1,
            Discount = 5,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/622291-800-auto?v=637480920176030000&width=800&height=auto&aspect=true"
        },
        new()
        {
            Name = "Turbo Ventilador Indelplas 20 Pulgadas",
            Description = "¡Aire limpio y fresco en tus ambientes! El ventilador Indelplas IVI20 es un elemento útil para dar frescura en el hogar. Con su óptimo rendimiento, la sensación térmica disminuirá. Es un aparato práctico, fácil de armar e instalar.",
            Price = 44657M,
            CategoryId = 1,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/724708-1600-auto?v=637997310617930000&width=1600&height=auto&aspect=true"
        },
        new()
        {
            Name = "Heladera C/freezer Samsung 299lt Silver",
            Description = "Estantes Removibles: Regulables | Display led en puerta: No | Cíclica: No",
            Price = 902999M,
            CategoryId = 1,
            Discount = 8,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/812513-1600-auto?v=638440520851230000&width=1600&height=auto&aspect=true"
        },
        new()
        {
            Name = "Celular Samsung Galaxy A04 128gb Negro",
            Description = "El celular Samsung Galaxy A04 128GB Negro es una verdadera joya tecnológica que te brindará una experiencia única.",
            Price = 227999M,
            CategoryId = 2,
            Discount = 20,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/759385-1600-auto?v=638041450311030000&width=1600&height=auto&aspect=true"
        },
        new()
        {
            Name = "Consola Ps5 Playstation Hw Standard",
            Description = "La consola PlayStation PS5 es la máxima experiencia de juego que estabas esperando. Sumérgete en mundos virtuales llenos de acción y aventura con gráficos impresionantes y una velocidad de carga ultrarrápida.",
            Price = 1119999M,
            CategoryId = 2,
            Discount = 15,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/788296-1200-auto?v=638252265728830000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Impresora Laser Brother Hl1212w",
            Description = "La Brother HL1212W es una impresora láser monocromática de alto rendimiento, ideal para uso doméstico y pequeñas oficinas. Con su diseño compacto en color negro y blanco, se adapta perfectamente a cualquier espacio de trabajo. Gracias a su tecnología láser, podrás disfrutar de impresiones de alta calidad y nitidez en todos tus documentos.",
            Price = 215999M,
            CategoryId = 2,
            Discount = 5,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/598942-1200-auto?v=637334034159330000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Notebook LENOVO LOQ 15,6'' I5 RTX 3050",
            Description = "La notebook Lenovo LOQ fue pensada para hacer tu vida más sencilla. Su diseño elegante e innovador y su comodidad para transportarla, la convertirá en tu PC favorita. Cualquier tarea que te propongas, ya sea en casa o en la oficina, la harás con facilidad gracias a su poderoso rendimiento.",
            Price = 1232498M,
            CategoryId = 2,
            Discount = 5,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/795886-1200-auto?v=638314365781300000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Bolso Playero Simil Raffia Urb X 1 U",
            Description = "Bolso moderno para la playa.",
            Price = 6499M,
            CategoryId = 3,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/797782-1200-auto?v=638337696642000000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Sombrero Capelina Dama Urb",
            Description = "Sombrero tipo capelina urbano para la playa.",
            Price = 3249M,
            CategoryId = 3,
            Discount = 12,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/797785-1200-auto?v=638337696653600000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Colitas De Pelo 6 U Urb",
            Description = "Colitas de pelo tipo urbano 6 unidades.",
            Price = 799M,
            CategoryId = 3,
            Discount = 12,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/807426-1200-auto?v=638412861722070000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Gorro Beba Minnie Disney",
            Description = "Gorras Disney para Bebes.",
            Price = 3999M,
            CategoryId = 3,
            Discount = 20,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/801385-1200-auto?v=638368908762100000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Reloj Colores 3c 20x4,4cm",
            Description = "Relojes de Pared.",
            Price = 4078M,
            CategoryId = 4,
            Discount = 15,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/719095-1200-auto?v=637985940510600000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Florero Rectangular 10x10x20cm",
            Description = "Florero de medidas 10 x 10 x 20 cm, realizado en vidrio.",
            Price = 6001M,
            CategoryId = 4,
            Discount = 2,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/622296-1200-auto?v=637480920189000000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Canastos Cinta Ecru L Krea",
            Description = "Canasto de decoración tipo cinta. Medidas: 32 x 25 x 20 cm",
            Price = 6808M,
            CategoryId = 4,
            Discount = 5,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/719010-1200-auto?v=637985940156570000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Espejo Decorativo D1 Krea",
            Description = "Espejo Decorativo Medidas: 34,5 x 34,5 x 2 cm.",
            Price = 4900M,
            CategoryId = 4,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/719089-1200-auto?v=637985940494870000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Jabón Líquido Para Manos Palmolive Naturals Camellia Refill 500 Ml",
            Description = "Nutrición para tu piel. Fragancia Irresistible. Espuma Cremosa.",
            Price = 2762M,
            CategoryId = 5,
            Discount = 12,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/801151-1200-auto?v=638368797875430000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Axe Desodorante Aerosol Bs Apollo 150ml",
            Description = "Tipo de Producto: Desodorantes en Aerosol.",
            Price = 2200M,
            CategoryId = 5,
            Discount = 15,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/793018-1200-auto?v=638300434822730000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Toallas Femeninas Siempre Libre Especial Suave X16u",
            Description = "Tipo de Producto: Toallitas Femeninas.",
            Price = 2804M,
            CategoryId = 5,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/789307-1200-auto?v=638264145869570000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Enjuague Bucal Listerine Cool Mint Frescura Intens X500",
            Description = "El enjuague bucal LISTERINE® Whitening Blanquea y Fortalece es un blanqueador con doble acción que además de blanquear los dientes, fortalece el esmalte dental dejándolos más fuertes.",
            Price = 4615M,
            CategoryId = 5,
            Discount = 30,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/804067-1200-auto?v=638382626558400000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Pelota De Futbol N5 Sorma",
            Description = "Tipo de Producto: Pelotas de Fútbol. Tamaño: N°5.",
            Price = 7995M,
            CategoryId = 6,
            Discount = 30,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/642182-1200-auto?v=637559538635470000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Pelota De Rugby Gilbert Oficial N° 5",
            Description = "Gilbert es la pelota oficial de Rugby World Cup 2023.",
            Price = 54999M,
            CategoryId = 6,
            Discount = 20,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/535715-1200-auto?v=636953449413130000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Pesa Rusa Plastica Agarre 6 Kg",
            Description = "Material: Recubrimiento de PVC, relleno de cemento y granalla. Agarre ergonómico.",
            Price = 8853M,
            CategoryId = 6,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/778232-1200-auto?v=638176882178670000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "TOBILLERA DE 1KG",
            Description = "La tobillera de 1kg viene con un velcro que se ajusta a tu tobillo para un mayor control y mejor performance en tus rutinas del gimnasio.",
            Price = 2955M,
            CategoryId = 6,
            Discount = 20,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/778197-1200-auto?v=638176882092600000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Peluches Plush 95 Cm",
            Description = "Peluches Plush N1. Sin Marca.",
            Price = 15999M,
            CategoryId = 7,
            Discount = 20,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/789434-1200-auto?v=638264362025230000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Rompecabezas Siluetas Antex",
            Description = "Puzzle Silueta Campo 2 Y 3 Piezas Carton Extra Antex 3023",
            Price = 5812M,
            CategoryId = 7,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/610452-1200-auto?v=637392787846270000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Surtido De Autos Hot Wheels X 1 Unidad",
            Description = "Edad Recomendada: 5 años.",
            Price = 3510M,
            CategoryId = 7,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/595921-1200-auto?v=637312441919370000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Ajedrez Linea Azul Ruibal",
            Description = "Una versión de lujo para el tradicional juego de ajedrez.",
            Price = 9075M,
            CategoryId = 7,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/788693-1200-auto?v=638254641877000000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Lomo De Atun Al Natural Cuisine & Co 120gr",
            Description = "Atún, agua, sal, pescado.",
            Price = 1875M,
            CategoryId = 8,
            Discount = 5,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/589055-1200-auto?v=637280470874970000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Galletitas Oreo 354g Sabor Original. Pack X 3 Unidades 118g",
            Description = "Para el desayuno, para merendar en familia, para snackear en el recreo del colegio o en la facultad o para compartir con amigos.",
            Price = 2800M,
            CategoryId = 8,
            Discount = 2,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/803300-1200-auto?v=638379382755670000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Galletitas ópera Agrupadas 220 Gr",
            Description = "Almendra, avellana, avena, cebada, centeno, maní.",
            Price = 952M,
            CategoryId = 8,
            Discount = 4,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/624009-1200-auto?v=637502527403100000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Gaseosa Pepsi Black Botella 1,5lt",
            Description = "La Pepsi Black no tiene azúcar.",
            Price = 828M,
            CategoryId = 8,
            Discount = 2,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/769354-1200-auto?v=638120073786470000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "En Agosto Nos Vemos",
            Description = "Comprá la novela inédita de gabriel garcía márquez unicamente en jumbo palermo, pilar y martenez y asegurá tu ejemplar antes del lanzamiento.",
            Price = 17999M,
            CategoryId = 9,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/808243-1200-auto?v=638418721433970000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "A Jugar Con Los Campeones",
            Description = "Historia, anécdotas y juegos.",
            Price = 2699M,
            CategoryId = 9,
            Discount = 5,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/783760-1200-auto?v=638215762552000000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Emociones Nutritivas",
            Description = "Como sentirnos mejor y crecer en nuestras circunstancias.",
            Price = 17549M,
            CategoryId = 9,
            Discount = 5,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/761564-1200-auto?v=638055922083100000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Mindfulness, Edición Actualizada",
            Description = "Primeros pasos para una nueva consciencia.",
            Price = 3960M,
            CategoryId = 9,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/761552-1200-auto?v=638055922052730000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Tierra Para Jardin Terrafertil X 10 Lts",
            Description = "Uso Recomendado: Jardínes, Canteros y Macetas.",
            Price = 2463M,
            CategoryId = 10,
            Discount = 8,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/498393-1200-auto?v=636786390868700000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Maceta Beruplast Autorriego Negra N°3",
            Description = "La Maceta Beruplast Autorriego Negra N°3 es una opción práctica y funcional para tus plantas.",
            Price = 1698M,
            CategoryId = 10,
            Discount = 15,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/795783-1200-auto?v=638313501793070000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Manguera De Riego Trenzada 15 M",
            Description = "La Manguera de Riego Trenzada x 15 metros es un producto de alta calidad para tus necesidades de riego. Su construcción trenzada la hace resistente y duradera, ideal para uso en jardines, huertos o cualquier área que requiera riego.",
            Price = 7903M,
            CategoryId = 10,
            Discount = 15,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/754264-1200-auto?v=638019634047770000&width=1200&height=auto&aspect=true"
        },
        new()
        {
            Name = "Fertilizante Terrafertil Triple 15 X 1 Kg",
            Description = "Este es un fertilizante ideal para mantener equilibradamente la nutrición de tus plantas asegurando su correcto crecimiento y desarrollo.",
            Price = 3793M,
            CategoryId = 10,
            Discount = 10,
            ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/505111-1200-auto?v=636822678999570000&width=1200&height=auto&aspect=true"
        },
    ];

    private static IEnumerable<Product> GetInitialProducts() => _products;
}
