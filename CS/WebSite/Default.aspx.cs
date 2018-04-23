using System;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;

public partial class _Default : System.Web.UI.Page {
    protected void ASPxRadioButtonList1_Init(object sender, EventArgs e) {
        ASPxRadioButtonList rb = (ASPxRadioButtonList)sender;
        
        GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)rb.NamingContainer;
        rb.ID = string.Format("rb_{0}", templateContainer.VisibleIndex);
        rb.ClientInstanceName = string.Format("rb_{0}", templateContainer.VisibleIndex);
        rb.ClientSideEvents.SelectedIndexChanged = string.Format("function(s, e) {{ OnSelectedIndexChangedEventHandler({0}, '{1}'); }}", rb.ClientInstanceName, templateContainer.VisibleIndex);
    }
    protected void ASPxComboBox1_Init(object sender, EventArgs e) {
        ASPxComboBox cmb = (ASPxComboBox)sender;
        
        GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)cmb.NamingContainer;
        cmb.ID = string.Format("cmb_{0}", templateContainer.VisibleIndex);
        cmb.ClientInstanceName = string.Format("cmb_{0}", templateContainer.VisibleIndex);
    }
    protected void ASPxMemo1_Init(object sender, EventArgs e) {
        ASPxMemo memo = (ASPxMemo)sender;
        
        GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)memo.NamingContainer;
        memo.ID = string.Format("memo_{0}", templateContainer.VisibleIndex);
        memo.ClientInstanceName = string.Format("memo_{0}", templateContainer.VisibleIndex);
    }
    protected void ASPxButton1_Click(object sender, EventArgs e) {
        int startIndex = ASPxGridView1.PageIndex * ASPxGridView1.SettingsPager.PageSize;
        int endIndex = Math.Min(ASPxGridView1.VisibleRowCount, startIndex + ASPxGridView1.SettingsPager.PageSize);

        for (int i = startIndex; i < endIndex; i++) {
            ASPxRadioButtonList rb = (ASPxRadioButtonList)ASPxGridView1.FindRowCellTemplateControl(i, (GridViewDataColumn)ASPxGridView1.Columns[4], string.Format("rb_{0}", i));
            ASPxComboBox cmb = (ASPxComboBox)ASPxGridView1.FindRowCellTemplateControl(i, (GridViewDataColumn)ASPxGridView1.Columns[5], string.Format("cmb_{0}", i));
            ASPxMemo memo = (ASPxMemo)ASPxGridView1.FindRowCellTemplateControl(i, (GridViewDataColumn)ASPxGridView1.Columns[5], string.Format("memo_{0}", i));
            //SAVE DATA
        }
    }
}