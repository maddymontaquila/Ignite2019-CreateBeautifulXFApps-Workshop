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

6. Now let's swap out the `ListView` for a more performant alternative - `CollectionView`, which is in preview in Xamarin.Forms 4.2. `CollectionView` automatically utilizes the virtualization capabilities of each native platform to make your lists appear faster. It also supports multiple columns of items, and a simpler API with no need for Cells. There are a few steps to change over your `ListView`:

6a. Stop debugging your app, as we are going to change some C#, which can't be done during a debug session.

6b. Go into the TodoListPage.xaml.cs file and comment out the `OnListItemSelected` function. Uncomment the version of it below labeled step 6.

6c. Open `TodoListPage.xaml`. Change all instances of `ListView` to `CollectionView`.

6d. Add `SelectionMode="Single"` to the opening tag of the `CollectionView`. This tells the `CollectionView` that you are only ever selecting one item at a time.

6e. Replace `ItemSelected` with `SelectionChanged` in the opening tag of the `CollectionView`.

6f. Delete the opening and closing `ViewCell` tags (keep the Grid and it's contents inside - CollectionView doesn't need a cell!)

At the end of step 6, the XAML for your `CollectionView` should look like:

```csharp
<CollectionView x:Name="myItems"
                Margin="20"
                 SelectionMode="Single"
                SelectionChanged="OnListItemSelected">
		<CollectionView.ItemTemplate>
			<DataTemplate>
                    <Grid Padding="10">
                        <!--#region Grid definitions-->
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="Auto" />
                        </Grid.ColumnDefinitions>
                        <!--#endregion-->
                        <Label Grid.Column="1"
                               Text="{Binding Name}"
                               FontAttributes="Bold" />
                        <Image Grid.Column="2" HorizontalOptions="End" Grid.RowSpan="2" IsVisible="{Binding Done}" >
                            <Image.Source>
                                <FontImageSource Glyph="&#xf12c;"
                                                FontFamily="{StaticResource MaterialFontFamily}"
                                                Size="32"
                                                Color="Green"/>
                            </Image.Source>
                        </Image>
                    </Grid>
			</DataTemplate>
		</CollectionView.ItemTemplate>
</CollectionView>
```

Start debugging your app again so we can begin customizing the `CollectionView` using XAML Hot Reload!

- under the data template add a frame around the grid , add a background colour around the fram `BackgroundColor = "blah"` and `IsClippedToBound=True` this does blah.

```csharp
<Frame BackgroundColour="Aquamarine" IsClippedToBounds="True>
...
</Frame>
```

- Notice that everything looks bad so we need to add some item spacing:

```csharp
<CollectionView.ItemsLayout>
            <ListItemsLayout ItemSpacing="20" Orientation="Vertical" />
</CollectionView.ItemsLayout>
```

next is make a frame around your Grid so the items are cute - choose your own background color and text color!

```csharp
<Frame BackgroundColor="LightPink" Padding="10" IsClippedToBounds="True" CornerRadius="5">
    <Label Grid.Column="1"
            Text="{Binding Name}"
            FontAttributes="Bold" />
    <Image Grid.Column="2" HorizontalOptions="End" Grid.RowSpan="2" IsVisible="{Binding Done}" >
        <Image.Source>
            <FontImageSource Glyph="&#xf12c;"
                            FontFamily="{StaticResource MaterialFontFamily}"
                            Size="32"
                            Color="Green"/>
        </Image.Source>
    </Image>
</Frame>
```

Let's add the ability to see the item description on the page too. Add another label with Grid.Row="1" and set Text={Binding Notes}. Customize the text however you like.

7. Next step is to comment out the MainPage in the App.xaml.cs, and we are going to use shell for describe our hierarchy. Add (or comment out) intializing a new shell page.

Shell description

8. Lets look at how to make this page use material design.


7. a11y

### <a id="android"></a>Android

1. Download and open the sample from GitHub in Visual Studio.






<Grid Padding="10">
                        <!--#region Grid definitions-->
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="Auto" />
                        </Grid.ColumnDefinitions>
                        <!--#endregion-->
                        <Label Grid.Column="1"
                               Text="{Binding Name}"
                               FontAttributes="Bold" />
                        <Label Grid.Row="1"
                               Grid.Column="1"
                               Text="{Binding Notes}"
                               FontAttributes="Italic"
                               VerticalOptions="End" />
                        <Image Grid.Column="2" HorizontalOptions="End" Grid.RowSpan="2" IsVisible="{Binding Done}" >
                            <Image.Source>
                                <FontImageSource Glyph="&#xf12c;"
                                                FontFamily="{StaticResource MaterialFontFamily}"
                                                Size="32"
                                                Color="Green"/>
                            </Image.Source>
                        </Image>
                    </Grid>