# MVVM frameworks comparison

Main goal is to compare popular MVVM frameworks by handling use cases of big enterprise applications with out-of-the-box features:
* Portable core (view models, business logic, etc) and views projects for different platforms
* DI support
* Tab navigation: add tab and handle it's closing
* Dialog navigation: open modal window and get result of show operation
* Page navigation: TODO
* Initialization of child navigable view model (window, tab, page)
* ICommand pattern implementation. CanExecuteChanged calling on view model property changed
* Handling window closing with ability to cancel it and do long task
* Ability to validate properties and notify view with INotifyDataErrorInfo
* Long operation indication in view model

Out-of-the box means that you don't need to write boilerplate code, messages, presenters, validators, etc to use this features. Feature counts only if it available on all platforms.

To compare frameworks, I created simple application:
* Main window with tab control and button
  * Button "Add new tab" add new composition form
  * All tabs should be closeable
* First tab is form with check box "Can open child window", text box with text parameter (which will be passed to child view model) and button "Open child window"
  * Child form is window with text box for editing passed parameter, and two button:
    * Update parameter: close window and update parameter in parent view model. Should be enabled only if parameter changed. Parameter check box should show error
    * Close: close window without parameter updating
    * Should be confirmation of child window closing with long prosess emulating
* Second tab is form with composite view model example: master view model with nested view models. Should be confirmation of form closing

# Participants (in progress)
- Caliburn.Micro ([Repository](https://github.com/Caliburn-Micro/Caliburn.Micro), [Stack Overflow](http://stackoverflow.com/questions/tagged/caliburn.micro))
- Catel ([Repository](https://github.com/catel/catel), [Stack Overflow](http://stackoverflow.com/questions/tagged/catel))
- Mugen MVVM Toolkit ([Repository](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit), [Stack Overflow](http://stackoverflow.com/questions/tagged/mugenmvvmtoolkit))
- MVVM Light Toolkit ([Repository](https://mvvmlight.codeplex.com/), [Stack Overflow](http://stackoverflow.com/questions/tagged/mvvm-light))
- MvvmCross ([Repository](https://github.com/MvvmCross/MvvmCross), [Stack Overflow](http://stackoverflow.com/questions/tagged/mvvmcross))
- Prism ([Repository](https://github.com/PrismLibrary/Prism), [Stack Overflow](http://stackoverflow.com/questions/tagged/prism))
- ReactiveUI ([Repository](https://github.com/reactiveui/ReactiveUI), [Stack Overflow](http://stackoverflow.com/questions/tagged/reactiveui))

Feature | Caliburn.Micro | Catel | Mugen MVVM Toolkit | MVVM Light Toolkit | MvvmCross | Prism | ReactiveUI
--- | --- | --- | --- | --- | --- | --- | ---
Core portable project | Yes | Yes | Yes | Yes | Yes | ? | ?
DI support | Yes | Yes | Yes | Yes | Yes | ? | ?
Tab navigation | ? | ? | Yes | ? | ? | ? | ?
Dialog navigation | No | Yes | Yes | No | No | ? | ?
Page navigation | ? | ? | ? | ? | ? | ? | ?
Passing parameters to navigable VM | - | Yes | Yes | - | - | ? | ?
Result of navigation operation | - | Yes | Yes | - | - | ? | ?
VM closing handling | - | Without cancellation | Yes | - | - | ? | ?
Handling VM navigation lifecycle | Yes | Yes | Yes | - | - | ? | ?
Update commands on property changed | Yes | Yes | Yes | No | No | ? | ?
Property validation | No | Yes | Yes | No | No | ? | ?
Busy indication | No | Without async | Yes | No | No | ? | ?

? - will be described later

# Conclusions (in progress)
- Caliburn.Micro: Small framework. Has WindowManager, but only for WPF (unavailable in portable library). Has commands/property binding implementations via xaml naming conventions, which are not very useful because of missed ReSharper suggestions. Has good samples and documentation.
- Catel: Huge heavyweight framework. Has good samples. Handles most of use cases, but with nuances. Doesn't support cancellation of closing operation. Doesn't support awaiting of long operation with busy indicator. Some parts of code looks overengineered (for example [#1](https://github.com/Catel/Catel/blob/51b8685daa31f7bbcf664b81612020e689737b09/src/Catel.Core/Catel.Core.Shared/Data/Interfaces/IAdvancedNotifyPropertyChanged.cs#L15), [#2](https://github.com/Catel/Catel/blob/51b8685daa31f7bbcf664b81612020e689737b09/src/Catel.MVVM/Catel.MVVM.Shared/MVVM/ViewModels/Interfaces/IProgressNotifyableViewModel.cs#L14)), some - [very strange](https://github.com/Catel/Catel/blob/51b8685daa31f7bbcf664b81612020e689737b09/src/Catel.Core/Catel.Core.Shared/Runtime/ReferenceEqualityComparer.cs#L39-L45).
- Mugen MVVM Toolkit: Winner of the comparison. Reference implementation. Has all desired features out-of-the-box. Has good samples for all platforms and features. For extending to another platform only native views are needed (WinForms project as example). Disadvantages: small community and complex internal source code.
- MVVM Light Toolkit: Most popular and most useless. Really light framework: doesn't have anything out-of-the-box, except base notifiable class, commands and event aggregator. Located on dying CodePlex, last updated in 2015. Outsider of the comparison.
- MvvmCross: Another popular, but not useful framework. Doesn't support dialog navigation, for page navigation supports passing only simple serializable types. Has ugly support of WPF (you can't even show VM as window).
- Prism: -
- ReactiveUI: -

# What next
1. Add page navigation sample
2. Add Xamarin.Forms projects
3. Add UWP projects
