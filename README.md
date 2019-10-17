# Create Beautiful Xamarin.Forms Apps – Ignite Workshop

## Objectives:

You should leave this workshop today knowing the following:

- how to create beautiful Xamarin.Forms app
- Use Hot Reload to iterate on your UI


## Before we begin – Choose your setup:

What OS are you using?

[Mac](#mac) | [Windows](#android)

### <a id="mac"></a>Mac

Do you have Xcode installed?

[Yes](#macios) | [No](#android)

### <a id="macios"></a>Visual Studio for Mac and iOS

1. Download and open the sample from GitHub in Visual Studio for Mac.
2. Open the .sln file within the **Start** folder. Once it opens in the IDE, double click on `TodoListPage.xaml` in the Views folder to open it in the editor.
3. The next step is to open with Hot Reload **Visual Studio > Preferences > Project > XAML Hot Reload** and select **Enable Hot Reload (Preview)**.

You'll then need to start debugging by selecting **Debug | iOS Simulator** and press the play button.
Feel free to play around with the app in the simulator.

4. We want to update the button to add a new item, using the FontImageSource capabilities available in Xamarin.Forms 4.0 and up. We have added the font file to the projects for you [Material Design Icons](materialdesignicons.com), and added the font as an app-wide `StaticResource`. To change the toolbar icon, replace the `ToolbarItem.IconImageSource` code in the `TodoListPage.xaml` file with:

```csharp
<ToolbarItem.IconImageSource>
    <FontImageSource 
        // The glyphs are represented as a 4 digit unicode symbol starting with '\'
        // You have to escape the backslash using '&#x'
        Glyph="&#xf183;"
        // This is the font we imported for you and put in App.xaml
        FontFamily="{StaticResource MaterialFontFamily}"
        Size="32" />
</ToolbarItem.IconImageSource>
```

We've chosen to use the "Add Message" glyph, but you can use any that you like from the [Material Design icons](https://cdn.materialdesignicons.com/4.5.95/) website.

5. Let's do the same with checkmark icon for each item. Find a [glyph]((https://cdn.materialdesignicons.com/4.5.95/)) you'd like to replace the existing icon with.

Replace the `<Image>` tag with:

```csharp
<Image HorizontalOptions="End" IsVisible="{Binding Done}" >
    // Change the source from a file (string) to a FontImageSource
    <Image.Source>
        <FontImageSource Glyph="&#xf12c;"
                            FontFamily="{StaticResource MaterialFontFamily}"
                            Size="32"
                            Color="Green"/>
    </Image.Source>
</Image>
```


customization list page and item page

5. polishing / swapping out the checks and pluses for a good icon
6. re-wire the app to go through a new app shell
7. a11y

### <a id="android"></a>Android

1. Download and open the sample from GitHub in Visual Studio.
