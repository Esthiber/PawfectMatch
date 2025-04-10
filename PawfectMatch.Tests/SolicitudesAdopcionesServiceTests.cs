using Microsoft.EntityFrameworkCore;
using PawfectMatch.Data;
using PawfectMatch.Models._Solicitudes;
using PawfectMatch.Services._Solicitudes;
using Xunit;

namespace PawfectMatch.Tests
{


    public class SolicitudesAdopcionesServiceTests
    {
        private IDbContextFactory<ApplicationDbContext> CrearDbFactory()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Nueva instancia para cada prueba
                .Options;

            var factoryMock = new DbContextFactoryMock(options);
            return factoryMock;
        }

        [Fact]
        public async Task InsertAsync_DeberiaGuardarSolicitud()
        {
            // Arrange
            var factory = CrearDbFactory();
            var service = new SolicitudesAdopcionesService(factory);

            var solicitud = new SolicitudesAdopciones
            {
                MascotaId = 3,
                AdoptanteId = 1,
                EstadoSolicitudId = 1
            };

            // Act
            var resultado = await service.InsertAsync(solicitud);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public async Task SearchAsync_DeberiaEncontrarSolicitud()
        {
            var factory = CrearDbFactory();
            var service = new SolicitudesAdopcionesService(factory); var encontrada = await service.SearchByIdAsync(1);
            Assert.Equal(1, encontrada.SolicitudAdopcionId);

        }

        [Fact]
        public async Task UpdateAsync_DeberiaActualizar()
        {
            // Arrange
            var factory = CrearDbFactory();
            var service = new SolicitudesAdopcionesService(factory);

            SolicitudesAdopciones solicitud = await service.SearchByIdAsync(2);

            solicitud.EstadoSolicitudId = 2;
            var actualizada = await service.UpdateAsync(solicitud);


            Assert.True(actualizada);
        }

    }

}
