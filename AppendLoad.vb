DropDownBox的KeyPress事件代码设置为：

Dim drp As WinForm.DropDownBox = e.Sender
If drp.DroppedDown = False '如果下拉窗口没有打开
    drp.OpenDropDown() '打开下拉窗口
End If

DropDownBox的TextChanged事件代码设置为：

Dim drp As WinForm.DropDownBox = e.sender
If drp.DroppedDown Then '如果下拉窗口已经打开
    Dim tbl As Table = Tables("客户信息选择_Table1")
    If drp.Text = "" Then '如果内容为空
        tbl.Filter = "" '显示所有客户
    Else '否则根据输入内容进行模糊筛选
        Dim txt As String = "'%" & drp.Text & "%'"
        tbl.Filter = "Customer Like " & txt & " Or idNumber Like " & txt & " Or Contect Like " & txt & " Or Mobil Like " & txt
    End If
End If

DropDownBox的KeyDown事件代码设置为：

Dim drp As WinForm.DropDownBox = e.sender
If drp.DroppedDown Then '如果下拉窗口已经打开
    Dim tbl As Table = Tables("客户信息选择_Table1")
    If e.KeyCode = Keys.Up Then '如果按下的是上箭头按键
        tbl.Position = tbl.Position - 1 '向上移动一行
        e.Cancel = True
    ElseIf e.KeyCode = Keys.Down Then '如果按下的是下箭头按键
        tbl.Position = tbl.Position + 1 '向下移动一行
        e.Cancel = True
    End If
End If

'窗口的DropDownOpened事件代码

客户信息选择_DropDownOpened

Dim txt As String = e.Form.DropDownBox.Text
'Dim tbl As Table = Tables("客户信息选择_Table1")

With DataTables("Custom")
    If txt = "" Then
        .LoadFilter = "" '一定要清除加载条件
    Else
        txt = "'%" & txt & "%'"
        .LoadFilter = "Customer Like " & txt & " Or idNumber Like " & txt & " Or Contect Like " & txt & " Or Mobil Like " & txt
        .Load()
    End If
End With

If e.Table.Current IsNot Nothing Then
    Dim Filter As String = "OwnerIDnumber = " & e.Table.Current("idNumber") 
    If  DataTables("VehicleInfo").Find(Filter) Is Nothing Then '如果对应的订单明细没有加载过
        DataTables("VehicleInfo").AppendLoad(Filter) '则追载此订单的订单明细
    End If
End If
e.Form.DropDownBox.Select() '将输入焦点返回下拉列表框


http://www.foxtable.com/help/scr/1788.htm

Dim txt As String = e.Form.Controls("TextBox3").Text
Dim tbl As Table = Tables("客户信息选择_Table1")
If txt = "" Then '如果内容为空
    tbl.Filter = "" '显示所有客户
Else '否则根据输入内容进行模糊筛选
    txt = "'%" & txt & "%'"
    tbl.Filter = "Customer Like " & txt & " Or idNumber Like " & txt & " Or Contect Like " & txt & " Or Mobil Like " & txt
End If

Tables("订单").ApplyFilter = False

e.Form.Controls("EndDate").Value = Nothing
e.Form.Controls("rdoAll").Checked = True

客户窗口重置控件
e.Form.Controls("Search").Value = Nothing

With DataTables("Custom")
    .LoadFilter = "" '一定要清除加载条件
    .LoadReverse = 25
    .LoadPage = 0
    .Load()
End With

下面这段有问题
Dim tbl As Table = Tables("Custom")
If tbl.Current IsNot Nothing Then
    Dim Filter As String = "OwnerIDnumber = " & tbl.Current("idNumber")
    If  DataTables("VehicleInfo").Find(Filter) Is Nothing Then '如果对应的明细没有加载过
        DataTables("VehicleInfo").AppendLoad(Filter) '则追载相应库明细
    End If
End If

e.Form.Controls("rdoAll").Checked = True '逻辑字段
