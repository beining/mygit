If e.Value IsNot Nothing Then
	Select case e.Value
		case "未核保"
			e.Text = "报价单"
		case "已核保"
			e.Text = "报价单"
		case "已缴款"
			e.Text = "销售单"
		case "已结清"
			e.Text = "销售单"
		case "批改"	
			e.Text = "批改单"
		case "退保"	
			e.Text = "退保单"
	End Select
End If

'项目属性
'MainTableChanged

Syscmd.Project.StopRedraw()
For Each frm As WinForm.Form In Forms
   frm.Close()
Next
Application.DoEvents()
Select Case MainTable.Name
    Case "凭证"
        Forms("凭证").Show()
    Case "支票"
        Forms("支票").Show()
    Case "对帐单"
        Forms("对帐单").Show()
End Select
Syscmd.Project.ResumeRedraw()