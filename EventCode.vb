项目事件

AfterOpenProject

'关闭表
'If User.Type <> UserTypeEnum.Developer
'    TableCaptionVisible = False
'End If

'------增加下拉窗体
Tables("VehicleInfo").Cols("OwnerIDnumber").DropForm = "客户信息选择"

'------加载主窗口
Forms("客户").Open()
'------动态加载"客户"表
With DataTables("Custom")
    .LoadFilter = "" '一定要清除加载条件
    .LoadReverse = 25
    .LoadPage = 0
    .Load()
End With

计划管理

表事件

VehicleInfo_ValidateEdit

If e.Col.DroppedDown Then '如果下拉窗口已经打开
    e.Col.CloseDropDown() '则关闭下拉窗口
End If

VehicleInfo_ChangeEdit

If e.Col.Name = "OwnerIDnumber" Then '如果编辑的是"所有人"列
    If e.Col.DroppedDown Then '如果下拉窗口已经打开
        Dim tbl As Table = Tables("客户信息选择_Table1") 
        If e.Text = "" Then '如果内容为空
            tbl.Filter = "" '显示所有客户
        Else '否则根据输入内容进行模糊筛选
            Dim txt As String = "'%" & e.Text & "%'"
            tbl.Filter = "Customer Like " & txt & " Or idNumber Like " & txt & " Or Contect Like " & txt & " Or Mobil Like " & txt
        End If
    End If
End If

VehicleInfo_KeyPressEdit

If e.Col.Name = "OwnerIDnumber" Then '如果编辑的是客户ID列
    If e.Col.DroppedDown = False '且下拉窗口没有打开
        e.Col.OpenDropDown() '打开下拉窗口
    End If
End If

VehicleInfo_KeyDownEdit

If e.Col.Name = "OwnerIDnumber" Then '如果编辑的是客户 ID列
    If e.Col.DroppedDown Then '如果下拉窗口已经打开
        Dim tbl As Table = Tables("客户信息选择_Table1")
        If e.KeyCode = Keys.Up Then '如果按下的是上箭头按键
            tbl.Position = tbl.Position - 1 '向上移动一行
            e.Cancel = True
        ElseIf e.KeyCode = Keys.Down Then '如果按下的是下箭头按键
            tbl.Position = tbl.Position + 1 '向下移动一行
            e.Cancel = True
        End If
    End If
End If

VehicleInfo_DataColChanged

If e.DataCol.Name = "OwnerIDnumber" Then
    Dim dr As DataRow
    dr = DataTables("Custom").Find("[idNumber] = '" & e.DataRow("OwnerIDnumber") & "'")
    If dr IsNot Nothing Then
        e.DataRow("Owner") = dr("Customer")
        e.DataRow("OwnerAdd") = dr("IDAddress")
    Else
        '否则清除两列的内容
        e.DataRow("Owner") = Nothing
        e.DataRow("OwnerAdd") = Nothing
        
    End If
End If

窗口表事件

_Table1_DoubleClick

Forms("客户信息选择").DropDownBox.CloseDropDown()

_Table1_KeyDown

If e.KeyCode = Keys.Enter Then
    Forms("客户信息选择").DropDownBox.CloseDropdown()
End If

窗口与控件事件

Order_Label17_DataFormat

If e.Value IsNot Nothing Then
    Select Case e.Value
        Case "未核保"
            e.Text = "报价单"
        Case "已核保"
            e.Text = "报价单"
        Case "已缴款"
            e.Text = "销售单"
        Case "已结清"
            e.Text = "销售单"
        Case "批改"
            e.Text = "批改单"
        Case "退保"
            e.Text = "退保单"
    End Select
End If

车辆信息编辑_AfterLoad

For Each frm As WinForm.Form In Forms '关闭本表其他窗口
    If frm.TableName = e.Form.TableName AndAlso frm.Opened Then
        If frm.Name <> e.Form.Name Then
            frm.Close
        End If
    End If
Next

车辆信息编辑_Button1_Click

With DataTables("Custom")
    If .LoadPage <> 0 Then
       .LoadTop = 25
       .LoadPage = 0
       .Load()
    End If
End With

车辆信息编辑_Button10_Click

Tables("Custom.VehicleInfo").Current.Save()

车辆信息编辑_Button2_Click

With DataTables("Custom")
    If .LoadPage < .TotalPages - 1 Then
        .LoadPage = .LoadPage + 1
        .Load()
    End If
End With

车辆信息编辑_Button3_Click

With DataTables("Custom")
    If .LoadPage > 0 Then
        .LoadPage = .LoadPage - 1
        .Load()
    End If
End With

车辆信息编辑_Button4_Click

With DataTables("Custom")
    If .LoadPage < .TotalPages - 1 Then
        .LoadPage = .TotalPages - 1
        .Load()
    End If
End With

车辆信息编辑_Button5_Click

Tables("Custom").AddNew()

车辆信息编辑_Button6_Click

With Tables("Custom")
    If .Current IsNot Nothing Then
        .Current.Delete()
    End If
End With

车辆信息编辑_Button7_Click

Tables("Custom").Current.Save()
With DataTables("Custom")
    .LoadFilter = "" '一定要清除加载条件
    .LoadReverse = 25
    .LoadPage = 0
    .Load()
End With

车辆信息编辑_Button8_Click

Tables("Custom.VehicleInfo").AddNew()

车辆信息编辑_Button9_Click

With Tables("Custom.VehicleInfo")
    If .Current IsNot Nothing Then
        .Current.Delete()
    End If
End With

客户_AfterLoad

For Each frm As WinForm.Form In Forms '关闭本表其他窗口
    If frm.TableName = e.Form.TableName AndAlso frm.Opened Then
        If frm.Name <> e.Form.Name Then
            frm.Close
        End If
    End If
Next

客户_Button1_Click

With DataTables("Custom")
    If .LoadPage <> 0 Then
       .LoadTop = 25
       .LoadPage = 0
       .Load()
    End If
End With

客户_Button10_Click

Tables("Custom.VehicleInfo").Current.Save()

客户_Button2_Click

With DataTables("Custom")
    If .LoadPage < .TotalPages - 1 Then
        .LoadPage = .LoadPage + 1
        .Load()
    End If
End With

客户_Button3_Click

With DataTables("Custom")
    If .LoadPage > 0 Then
        .LoadPage = .LoadPage - 1
        .Load()
    End If
End With

客户_Button4_Click

With DataTables("Custom")
    If .LoadPage < .TotalPages - 1 Then
        .LoadPage = .TotalPages - 1
        .Load()
    End If
End With

客户_Button5_Click

Tables("Custom").AddNew()

客户_Button6_Click

With Tables("Custom")
    If .Current IsNot Nothing Then
        .Current.Delete()
    End If
End With

客户_Button7_Click

Tables("Custom").Current.Save()
With DataTables("Custom")
    .LoadFilter = "" '一定要清除加载条件
    .LoadReverse = 25
    .LoadPage = 0
    .Load()
End With

客户_Button8_Click

Tables("Custom.VehicleInfo").AddNew()

客户_Button9_Click

With Tables("Custom.VehicleInfo")
    If .Current IsNot Nothing Then
        .Current.Delete()
    End If
End With

客户信息编辑_Button1_Click

e.form.Close()

客户信息选择_Button1_Click

e.Form.DropDownBox.CloseDropdown(False) 
Dim r As Row = Tables("Custom").AddNew()
Forms("客户信息编辑").Open()
r.Save()
e.Form.DropDownBox.Value = r("Customer")

客户信息选择_DropDownClosed

If e.Selected Then
    Dim tbl As Table = Tables("客户信息选择_Table1")
    If tbl.Current IsNot Nothing Then
        e.Form.DropDownBox.Value = tbl.Current("idNumber")
    End If
    If e.Form.DropTable IsNot Nothing Then '如果是通过表下拉的
        e.Form.DropTable.FinishEditing()
    Else '如果是通过窗口下拉的
        e.Form.DropDownBox.WriteValue()
    End If
End If

客户信息选择_DropDownOpened

Dim txt As String = e.Form.DropDownBox.Text
Dim tbl As Table = Tables("客户信息选择_Table1")
If txt = "" Then
    tbl.Filter = ""
Else
    txt = "'%" & txt & "%'"
    tbl.Filter = "Customer Like " & txt & " Or idNumber Like " & txt & " Or Contect Like " & txt & " Or Mobil Like " & txt
End If
e.Form.DropDownBox.Select() '将输入焦点返回下拉列表框

自定义函数

全局代码

Default



菜单事件


