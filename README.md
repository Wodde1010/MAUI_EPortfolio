# MAUI_EPortfolio

![some MAUI logo](LiveMauiDemo/Resources/Images/dotnet_bot.svg)

## Allgemeine Informationen

In meinem EPortfolio werde ich euch .NET MAUI vorstellen.

MAUI steht für Multi-Platform App UI und ist ein künftiges Framework innerhalb der dotnet Umgebung für die Entwicklung nativer Anwendungen. 

Da sich MAUI aktuell noch in der Entwicklung befindet, müssen die benötigten Workloads teils unabhängig von dotnet installiert werden. Glücklicherweise steht jedoch bereits ein hilfreiches Tool zur Verfügung. (Anleitung siehe unten)

Das MAUI Repository von Microsoft ist [hier](https://github.com/dotnet/maui) zu finden. Dort kann der aktuelle Stand geprüft oder Feedback gegeben werden.


Ich werde mit euch die Inhalte der [Presentation](maui.pdf) durchgehen und zu Demonstrationszwecken das hier abgelegte [Projekt](LiveMauiDemo) erstellen und analysieren.


## Installation und erste Schritte unter Windows und MacOS
### Stand Preview 3

- siehe offizielle [Dokumentation](https://github.com/dotnet/maui/wiki/Getting-Started)
- Mit kommenden Releases werden sich ggf. die aufgeführten Schritte ändern!

### 1. Visual Studio, bzw. .NET Umgebung installieren
 - Installer ist [hier](https://visualstudio.microsoft.com/de/) zu finden
### 2. VS Code installieren
 - Kann [hier](https://code.visualstudio.com/) heruntergeladen werden
### 3. Android Emulator
 - im Visual Studio unter Extras -> Android -> Android-Geräte-Manager -> gewünschten Emulator installieren ("+ neu")  und starten
### 4. in der Konsole:

* `>dotnet tool install -g redth.net.maui.check`

* `>maui-check`

  *  alle Pakete installieren (mit "y" jeweils bestätigen)

### 5. erstes Projekt

* `> dotnet new maui -n myFirstMauiProject`

  *  erstellt ein einfaches MAUI Projekt

* `> code ./myFirstMauiProject`

  *  öffnet das Projekt in VS Code

  *  im Projekt innerhalb des Root-Folders eine "nuget.config" Datei erstellen und folgendes Snippet einfügen:

```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="dotnet6" value="https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet6/nuget/v3/index.json" />
    <add key="xamarin" value="https://pkgs.dev.azure.com/azure-public/vside/_packaging/xamarin-impl/nuget/v3/index.json" />
  </packageSources>
</configuration>
```
* in der Konsole:

   *  `>cd pathOfRootProjectFolder`
    
   *  `>dotnet restore`
    
   *  `>dotnet build -t:Run -f net6.0-android`

   *  bei korrekter Installation sollte nun die App im Android Emulator gestartet werden (Startzeit kann ggf. noch recht groß sein)

* falls Touch- und Screenbereich beim Emulator nicht übereinstimmt:
    *  navigiere zu "C:\Program Files (x86)\Android\android-sdk\emulator\qemu\windows-x86_64"
    *  Rechtsklick auf die eingesetzte "qemu-system… .exe"
    *  Eigenschaften -> Kombatibilität -> "Hohe DPI-Einstellungen ändern": zu Überschreiben durch System ändern
