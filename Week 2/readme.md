# Week two: Implementing user interfaces in .NET MAUI  

In week two of the module we explore how we can create user interfaces (UIs) using XAML in Microsoft .NET MAUI. We explore different layout definitions such as stacks, grids, absolute and flexible layout. The use of resource dictionaries and styles to define common layouts for UI controls is also explored.  

## Repository content  

The code demonstrates how to layout UI elements using a variety of layout structures in addition to defining common UI controls such as text, input fields and buttons. Demos include:  

- **AbsoluteLayoutDemo** - Demonstates how to use the [AbsoluteLayout](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/absolutelayout) to position and size children UI controls using explicit values.  
- **DynamicTheme** - Demonstrates how to dynamically change the [style](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/styles/xaml)/[theme](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/theming) your .NET MAUI application uses during runtime.  
- **FlexLayoutDemo** - Demonstrats how to use the [FlexLayout](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/flexlayout) to arrange children UI controls.  
- **GridLayoutDemo** - Demonstrats how to use the [Grid](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/grid) to arrange children UI controls in a clean grid like fashion.  
- **LoginUI** - Demonstrats how to create a very basic login screen for a .NET MAUI application.  
- **MarkUpExtDemo** - Demonstrates how to use XAML [markup extensions](https://learn.microsoft.com/en-us/dotnet/maui/xaml/fundamentals/markup-extensions) to set properties in object that you can reference indirectly from other sources. This examples demonstates how to access static fields within the application that are used to store default values for UI elements such as label font size.  
- **MaterialDesign** - Demonstrates how you can use the [UraniumUI](https://enisn-projects.io/docs/en/uranium/latest) with an existing .NET MAUI project to incorporate Google's material design controls into your application. This [video](https://www.youtube.com/watch?v=7SxdgdbOHBc) will walk you through the process of adding Uranium UI to your project.  
- **ResourceDictionaryDemo** - This code example demonstrates how to use [resource dictionaries](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/resource-dictionaries) in .NET MAUI. Resource dictionaries are repositories that store application resources. Most commonly styles, and colours for your application. This demo illustates the difference between  StaticResource and DynamicResource to change the colour of UI elements dynamically during program execution.  
- **StackLayoutDemo** - This demo illustates hhow to use the [StackLayout](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/stacklayout) to position UI elements in a stack with a horizontal or vertical alignment.  
- **StylesDemo** - Normally the [style](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/styles/xaml) of a UI element is defined in the Styles.xaml file and becomes part of the application resource dictionary. The StylesDemo illustrates how to define visual styles for UI controls within the XAML file where the control is defined.  




If you notice any issues or errors create an issue or better still offer a solution and create a pull-request.  
