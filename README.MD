# Tab Control

An easy to use Xamarin Control which extends the Label View so it is esily customisable and extendable

## Installation

At the moment the best way to install this Control is to copy the raw code from <strong>src/Tab.cs</strong> and
add it into your project by replacing the namespace with your own

## Usage

The following is a list of properties other than Label based properties that it accepts:

| Property              | Function                                                                              |
|-----------------------|---------------------------------------------------------------------------------------|
| Status                | 0 or 1, tells the visual renderer whether to render it as active or inactive          |
| ActiveBackgroundColor | The background color of the control when it is active                                 |
| ActiveTextColor       | The text color of the control when it is active                                       |
| NavPage               | A string representing the ContentPage that the control will navigate to when selected |

## Example

The example below illustrates the process of creating the control in XAML with <strong>local</strong> being the
declared namespace in your XAML file that references the control

```cs
<local:Tab
    x:Class="MyNamespace.Tab"
    Status="1"
    NavPage="MyNamespace.HomePage"
    BackgroundColor="White"
    ActiveBackgroundColor="#008080"
    ActiveTextColor="#FFFFFF"
    HorizontalTextAlignment="Center" 
    VerticalTextAlignment="Center"
    Grid.Row="0" 
    Grid.Column="0" 
    Text="Home" />
<local:Tab 
    x:Class="MyNamespace.Tab"
    Status="0"
    NavPage="MyNamespace.ProfilePage"
    ActiveBackgroundColor="#008080"
    ActiveTextColor="#FFFFFF"
    BackgroundColor="White"
    HorizontalTextAlignment="Center"
    VerticalTextAlignment="Center"
    Grid.Row="0" 
    Grid.Column="1" 
    Text="Profile" />
```