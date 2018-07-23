# KarveCar
## Directory Description
* Commands: Contains commands to be used from main window view model.
* Controls: Contains the Karve custom and user control library. It is a set composed of custom controls  and attached properties.
* KarveWebApi: WebApi Infrastructure code. There is just a single controller.
* KarveWeb: BootstrapV4 MVC web Frontend and controllers.
* KarveSetup: Wix Skeleton for Setup.
* Modules: Application Modules.
  1. BookingModule. Module for the booking and reservation requests. Depends on DALModule
  2. KarveDataAccessLayer. Data Access Layer Module. It abstract the data base. Depends on KarveCommon and KarveCommonInterfaces
  3. CarModel. Module for handling car model, car brand, vehicule group.
  4. HelperModule. Module for managing all the small helper windows and their data. Depends on DALModule.
  5. PaymentTypesModule. Module for handling any kind of payment.
  6. ToolbarModule. Module for handling the toolbar.
* ViewModules: Main window ViewModels.
* Views: Main Views.
* Logic: deprectated.
* KarveCommonInterfaces: Global interfaces pakaged implemented in KarveCommon
* KarveCommon: common classes and interfaces.
* KarveCar.Navigation: High level API for creating and jumping to another view in the tab system.
* KarveCar.NavigationInterface: High level API for navigating between views.
* Utility: to review or deprecated
* Images: application image and graphics.
