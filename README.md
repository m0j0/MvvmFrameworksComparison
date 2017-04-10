# MVVM frameworks comparison

Main goal is to compare MVVM frameworks by handling of use cases of big enterprise applications with out-of-the-box features:
* Portable core (business logic, models, etc) with view models and views projects for different platforms
* DI support
* Dialog navigation: open modal window and get result of show operation
* Initialization of child navigable view model (window, page, etc)
* ICommand pattern implementation. CanExecuteChanged calling on view model property changed
* Handling window closing with ability to cancel it
* Ability to validate properties and notify view by INotifyDataErrorInfo
* Long operation indication in view model
Out-of-the box means that you don't need to write presenters, boilerplate code, messages, validators, etc to use this features.

To check, I created simple application with two windows:
* Main form is window with check box "Can open child window", text box with text parameter (which will be passed to child view model) and button "Open child window".
* Child form is window with text box for editing passed parameter, and two button:
  * Update parameter: close window and update parameter in parent view model. Should be enabled only if parameter changed. Parameter check box should show error.
  * Close: close window without parameter updating.
* Should be confirmation of child window closing with long prosess emulating. 

- [Caliburn.Micro](https://github.com/Caliburn-Micro/Caliburn.Micro)
- [Catel](https://github.com/catel/catel)
- [Mugen MVVM Toolkit](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)
- [MVVM Light Toolkit](https://mvvmlight.codeplex.com/)
- [MvvmCross](https://github.com/MvvmCross/MvvmCross)
- [Prism](https://github.com/PrismLibrary/Prism)
- [ReactiveUI](https://github.com/reactiveui/ReactiveUI)

Feature | Caliburn.Micro | Catel | Mugen MVVM Toolkit | MVVM Light Toolkit | MvvmCross | Prism | ReactiveUI
--- | --- | --- | --- | --- | --- | --- | ---
Core portable project | Yes | Yes | Yes | Yes | Yes | ? | ?
Dialog navigation | Yes? | Yes | Yes | No? | No | ? | ?
Passing parameters to navigable VM | Any types? | Yes | Any types | Any types? | Only primitives types | ? | ?
Result of navigation operation | No | Yes | Yes | No? | No | ? | ?
VM closing handling | Only synchronous operation | Without cancellation, ? | Yes | No | No | ? | ?
Update commands on property changed | Yes | Yes | Yes | No | No | ? | ?
Property validation | No | Yes | Yes | No | No | ? | ?
Busy indication | No | Without async | Yes | No | No | ? | ?
DI support | Yes | Yes | Yes | Yes | Yes | ? | ?
Handling VM lifecycle | Yes | ? | Yes | No | ? | ? | ?

? - will be described later

# Conclusion
- Caliburn.Micro: -
- Catel: -  
Doesn't support cancellation of closing operation. Doesn't support awaiting of long operation with busy indicator.
- Mugen MVVM Toolkit: -
- MVVM Light Toolkit: -
- MvvmCross: -
- Prism: -
- ReactiveUI: -

What next: -