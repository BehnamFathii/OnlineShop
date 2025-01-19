using OnlineShop.Store.Endpoints.HostedService.Extensions;

WebApplication.CreateBuilder(args).ConfigureService().ConfigurePipeline().Run();
