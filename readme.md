
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

* 在DataTemplate中的控件可以通过`Tag`属性，将Binding传入，作为
后续选中的哪一项的标识，如果是{Binding}，那么就是把Item整体传入。

* 从项容器获取数据，动态改变模板<详：DataTemplateDataTriggerDemo.xaml>

```xaml
<DataTemplate x:Key="listBoxItemTemplate">
            <Border Margin="5" BorderThickness="1" BorderBrush="SteelBlue" 
                    CornerRadius="4">
                <StackPanel Margin="3">
                    <TextBlock Text="{Binding Name}"/>
                    <StackPanel>
                        <StackPanel.Style>
                            <Style>
                                <Style.Triggers>
                                    <DataTrigger 
                                        Binding="{Binding Path=IsSelected, RelativeSource={
                                        RelativeSource 
                                        Mode=FindAncestor,
                                        AncestorType={x:Type ListBoxItem}
                                        }}" Value="false">
                                        <Setter Property="StackPanel.Visibility" Value="Collapsed"/>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </StackPanel.Style>
                        <TextBlock Margin="3" Text="{Binding Description}"
                                  TextWrapping="Wrap" MaxWidth="250" HorizontalAlignment="Left"/>
                        <Image Source="{Binding ImagePath}"/>
                    </StackPanel>
                </StackPanel>
            </Border>
        </DataTemplate>
```

* 视图
当创建一个绑定，WPF会创建一个叫做`视图`的对象，代表对象的集合，并且呈现那个集合到目标
控件。一个视图是一个`CollectionView`类的对象，并且管理数据的逻辑表示。可以执行如下功能：
(1) 保存集合中“当前”项的记录
(2)进行过滤---根据一些准则来逻辑化的排除一些数据成员[CollectionView的Filter属性，其中Filter是Func<bool,object>]
(3)根据指定的属性的值来排列数据对象[CollectionView的SortDescriptions,其中添加的是SortDescription对象]
(4)划分数据对象到不同的组

* ControlTemplate
WPF中，控件的外在模样和其功能是解耦的，外在模样可以通过ControlTemplate
来重新定义，如果还想通过Content来传递显示文字信息，就需要在ControlTemplate
中添加`<ContentPresenter/>`来定位，即`ContentPresenter`仅仅是一个占位符，
但值得注意的还有两点：（1）若要使用ContentPresenter，就必须为ControlTemplate设定
`TargetType`属性。（2）ControlPresenter若要使用其外在ControlTemplate的某些属性的值
可以通过`TemplateBinding`。

* 如果编译器看到一个程序的startupUri是一个Page，它就创建一个`NavigationWindow`来控制它，
* 这就是为什么在PageDemo中看，没有去指定导航宿主。


* 命令
实际应用程序中，如果要通过不同的动作和用户界面元素来执行一些相同的任务，最简单的虽然是将用户界面触发的事件都
绑定到一个执行该任务的方法，但当考虑该任务反向对用户界面的状态有影响时，问题就变得复杂了，如果没有正确
处理好用户界面状态，就可能会使不同状态的代码块不正确的相互重叠，从而导致某个控件在不应该可用的时候而
被启用。
幸运的是，命令可以解决这个问题，将相同的命令连接到不同控件，从而不需要重复编写事件处理代码，更重要的是
，当连接的命令不可用时，命令特性通过自动禁用控件来管理用户界面状态；当然，WPF命令仍然有一些重要的问题没有解决，
（1）命令跟踪（例如，保留最近命令的历史）（2）“可撤销的”命令（3）具有状态并可处于不同“模式”的命令（例如，
可被打开或关闭的命令）

`命令为什么需要路由事件`:
命令不应该由命令对象负责执行命令么？如果直接使用ICommand接口创建自己的命令，确实如此。代码应当被硬连接到命令，
从而可以通过相同的方式工作，而不管是什么操作触发了命令，这时，不需要事件冒泡。
然而，WPF使用了大量预先构建的命令，这些命令没有包含任何实际的代码，它们只是为了方便地定义代表常见应用程序
任务。**为了使用这些命令，需要使用命令绑定，为代码引发事件，为确保可在某个位置处理事件，甚至事件是由同一个窗口
的不同命令源引发的，所以需要使用事件冒泡的功能。
那么问题又来了，为什么非要使用预先构建的命令?因为它们为集成提供了更好的可能。例如，第三方开发人员可创建使用预先构建
的Print命令，只要应用程序使用相同预先构建的命令，在应用程序中关联打印时，就不需要做任何额外工作了。

`命令架构图`:

<img src="Resources\WPFCommandArchitecture.jpg">

触发命令库中的命令的最简单的方法是将它们关联到已实现了ICommandSource接口的控件，其中包括继承自`ButtonBase`类的控件
(Button,CheckBox（均为单击发送命令）),单独的ListBoxItem(双击时发送命令)，HyperLink（单击发送命令），以及MenuItem（单击发送命令）。

CommandBinding的CanExecute，Executed中的sender是CommandBinding被添加到的CommandBindings所在的控件。
如：
```xaml

<TextBox.CommandBindings>
    <CommandBinding Command=...
    />
</TextBox.CommandBindings>

```
那么上述的CommandBinding的Executed，CanExecute中的sender就是该TextBox。

* ListBox由于条目比较多，自动出现了scrollViewer时候，滚动中键，
* 实现ListBox滚动的方法，详`CommandDemoC.xaml`：
`方法一`:
 ````c#

private void initBindMouseWheel()
        {
            PreviewMouseWheel += (sender, e) =>
            {
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, 1, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                this.lstHistory.RaiseEvent(eventArg);
            };
        }

```
`方法二`:
外层包裹一个ScrollViewer
```xaml
<ScrollViewer Grid.Row="3" BorderBrush="Black" BorderThickness="1" Margin="5" x:Name="scrollViewer" MouseWheel="scrollViewer_MouseWheel">
            <ListBox Grid.Row="3" Name="lstHistory" Margin="5" DisplayMemberPath="CommandName" >
            </ListBox>
        </ScrollViewer>

```

```c#
MainWindow.cs:
窗体构造函数中：
this.lstHistory.AddHandler(PreviewMouseWheelEvent, new MouseWheelEventHandler(lstHistory_MouseWheel));

private void lstHistory_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                scrollViewer.LineUp();
            }
            else
            {
                scrollViewer.LineDown();
            }
        }

```

