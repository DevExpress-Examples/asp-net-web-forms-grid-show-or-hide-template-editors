Imports System
Imports DevExpress.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub ASPxRadioButtonList1_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim rb As ASPxRadioButtonList = DirectCast(sender, ASPxRadioButtonList)

        Dim templateContainer As GridViewDataItemTemplateContainer = CType(rb.NamingContainer, GridViewDataItemTemplateContainer)
        rb.ID = String.Format("rb_{0}", templateContainer.VisibleIndex)
        rb.ClientInstanceName = String.Format("rb_{0}", templateContainer.VisibleIndex)
        rb.ClientSideEvents.SelectedIndexChanged = String.Format("function(s, e) {{ OnSelectedIndexChangedEventHandler({0}, '{1}'); }}", rb.ClientInstanceName, templateContainer.VisibleIndex)
    End Sub
    Protected Sub ASPxComboBox1_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim cmb As ASPxComboBox = DirectCast(sender, ASPxComboBox)

        Dim templateContainer As GridViewDataItemTemplateContainer = CType(cmb.NamingContainer, GridViewDataItemTemplateContainer)
        cmb.ID = String.Format("cmb_{0}", templateContainer.VisibleIndex)
        cmb.ClientInstanceName = String.Format("cmb_{0}", templateContainer.VisibleIndex)
    End Sub
    Protected Sub ASPxMemo1_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim memo As ASPxMemo = DirectCast(sender, ASPxMemo)

        Dim templateContainer As GridViewDataItemTemplateContainer = CType(memo.NamingContainer, GridViewDataItemTemplateContainer)
        memo.ID = String.Format("memo_{0}", templateContainer.VisibleIndex)
        memo.ClientInstanceName = String.Format("memo_{0}", templateContainer.VisibleIndex)
    End Sub
    Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim startIndex As Integer = ASPxGridView1.PageIndex * ASPxGridView1.SettingsPager.PageSize
        Dim endIndex As Integer = Math.Min(ASPxGridView1.VisibleRowCount, startIndex + ASPxGridView1.SettingsPager.PageSize)

        For i As Integer = startIndex To endIndex - 1
            Dim rb As ASPxRadioButtonList = CType(ASPxGridView1.FindRowCellTemplateControl(i, CType(ASPxGridView1.Columns(4), GridViewDataColumn), String.Format("rb_{0}", i)), ASPxRadioButtonList)
            Dim cmb As ASPxComboBox = CType(ASPxGridView1.FindRowCellTemplateControl(i, CType(ASPxGridView1.Columns(5), GridViewDataColumn), String.Format("cmb_{0}", i)), ASPxComboBox)
            Dim memo As ASPxMemo = CType(ASPxGridView1.FindRowCellTemplateControl(i, CType(ASPxGridView1.Columns(5), GridViewDataColumn), String.Format("memo_{0}", i)), ASPxMemo)
            'SAVE DATA
        Next i
    End Sub
End Class