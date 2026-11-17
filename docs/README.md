🇬🇧 **English** | 🇺🇦 [Українська](README.uk.md)

# 🚗 Lab11: Structural Patterns in a Car-Sharing Service

A **C# / .NET** console project: four problem situations of "Miskavto" solved with **Adapter**, **Facade**, **Proxy** and **Decorator**. Events are logged as `[time] [source] event`.

| Task | Problem | Pattern | Solution |
|---|---|---|---|
| 1 | Vendor telematics uses DMS and liters | **Adapter** | `VendorTelematicsAdapter` converts in one place |
| 2 | Trip start steps duplicated in app and dispatcher | **Facade** | `TripFacade.StartTrip` |
| 3 | Anyone could command someone else's car | **Proxy** | `CarControlProxy` checks the renter, logs commands |
| 4 | Class explosion for option combinations | **Decorator** | `TripOptionDecorator` and option classes |

**Authors:** Katya, Stas. **Run:** `dotnet build`, `dotnet run`, choose `1`-`4`. Diagrams: `docs/diagrams/`. Peer review: `REVIEW.md`.