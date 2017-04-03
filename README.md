# MVVM frameworks comparison
Comparison of popular MVVM frameworks by **out-of-the-box WPF features**:

- [Caliburn.Micro](https://github.com/Caliburn-Micro/Caliburn.Micro)
- [Catel](https://github.com/catel/catel)
- [Mugen MVVM Toolkit](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)
- [MVVM Light Toolkit](https://mvvmlight.codeplex.com/)
- [MvvmCross](https://github.com/MvvmCross/MvvmCross)
- [Prism](https://github.com/PrismLibrary/Prism)
- [ReactiveUI](https://github.com/reactiveui/ReactiveUI)

Feature | Caliburn.Micro | Catel | Mugen MVVM Toolkit | MVVM Light Toolkit | MvvmCross | Prism | ReactiveUI
--- | --- | --- | --- | --- | --- | --- | ---
Core portable project | Yes | ? | Yes | ? | Yes | ? | ?
Dialog navigation | Yes | ? | Yes | ? | No | ? | ?
Passing parameters to navigable VM | Any types | ? | Any types | ? | Only primitives types | ? | ?
Result of navigation operation | No | ? | Yes | ? | No | ? | ?
VM closing handling | Only synchronous operation | ? | Yes | ? | No | ? | ?
Update commands on property changed | Yes | ? | Yes | ? | No | ? | ?
Property validation | No | ? | Yes | ? | No | ? | ?
Busy indication | No | ? | Yes | ? | No | ? | ?
DI support | Yes | ? | Yes | ? | Yes | ? | ?
Handling VM lifecycle | Yes | ? | Yes | ? | ? | ? | ?