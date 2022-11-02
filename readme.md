
在Git命令窗口，执行解除SSL验证命令脚本完成设置操作。
```c#

git config --global http.sslVerify "false"

```

本仓库仅用作wpf的各种方面的测试，学习。

This repository is only for the purpose of 
small demos of test or study of WPF.

* 逻辑树可以扩展为细节更丰富的可视化树，but how?
how this works? and why we need to learn about this?

原因在于，**每个控件都有一个内置的方法，用于确定如何渲染控件（作为一组
更基础的元素），该方法称为`控制模板（control template)`，是用
xaml标记块定义的**

需要学习的原因是，虽然可以通过样式来改变可视化中的元素，改变控件的外观，
但有些特定的细节很难，甚至无法修改，因此，可以诉诸于可视化树，来解决这个问题，
此外，可为控件创建新模板，对于这种情况，控件模板将用于按期望的方式构件
可视化树。

* DataTemplate和ControlTemplate的区别：
DataTemplate是用以控制展现数据的方式，是与数据相关的，所以是`ItemTemplate`的
值，而DataTemplate中用binding来绑定从ItemSource传来的数据。
ControlTemplate是单纯用来改变控件外形的，与数据无关，比如
Button.Template的值就是ControlTemplate类型，是构建可视化树的工具。
**也就是说ItemControl打破了，里面是DataTemplate来定义如何展现数据的
而ControlTemplate就是普通的控件，打破了，往里面看，更微小的构造**

* Margin控制的是控件与控件的距离，Padding控制的是内部文字与控件外边缘的距离。

