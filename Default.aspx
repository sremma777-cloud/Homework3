<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Homework 2</title>
</head>
<body style="height: 888px; width: 1173px; margin-top: 0px;">
    <form id="form1" runat="server" style="position: absolute; top: -20px; left: 10px; height: 1077px; width: 1129px;">
        <div style="position: absolute; top: 76px; left: 894px; height: 28px; width: 223px;">
            <asp:Label ID="lblErrorMessage" runat="server" Style="margin-top: 40px;"></asp:Label>
            </div>
           <div style="position: absolute; top: 53px; left: -1px; right: 96px; height: 198px;">
               <asp:GridView ID="gvDisplay" runat="server" Height="59px" style="margin-left: 560px; margin-top: 55px" Width="309px">
               </asp:GridView>
               </div>
        <div style="height: 101px; margin-top: 326px">
            <asp:Button ID="btnCreateCourse" runat="server" Text="Create Course" OnClick="btnCreateCourse_Click" />
            <asp:Button ID="btnLoadCourse" runat="server" OnClick="btnLoadCourse_Click" Text="Load Course" />
            <asp:Button ID="btnViewCourse" runat="server" Text="View Course" OnClick="btnViewCourse_Click" />
            <asp:Button ID="btnDeleteCourse" runat="server" Text="Delete Course" OnClick="btnDeleteCourse_Click" />
            <asp:ListBox ID="lstCourse" runat="server" Visible="False"></asp:ListBox>
            
            
            
        </div>
        <asp:Button ID="btnCreateStudent" runat="server" Text="Create Student" OnClick="btnCreateStudent_Click" />
        <asp:Button ID="btnLoadStudent" runat="server" OnClick="btnLoadStudent_Click" Text="Load Student" />
        <asp:Button ID="btnViewStudent" runat="server" Text="View Student" OnClick="btnViewStudent_Click" />
        <asp:Button ID="btnDeleteStudent" runat="server" Text="Delete Student" OnClick="btnDeleteStudent_Click" />
        <asp:ListBox ID="lstStudent" runat="server" Visible="False"></asp:ListBox>
        <p>
            <asp:Button ID="btnCreateFaculty" runat="server" Text="Create Faculty" OnClick="btnCreateFaculty_Click" />
            <asp:Button ID="btnLoadFaculty" runat="server" OnClick="btnLoadFaculty_Click" Text="Load Faculty" />
            <asp:Button ID="btnViewFaculty" runat="server" Text="View Faculty" OnClick="btnViewFaculty_Click" />
            <asp:Button ID="btnDeleteFaculty" runat="server" Text="Delete Faculty" OnClick="btnDeleteFaculty_Click" />
            <asp:ListBox ID="lstFaculty" runat="server" Visible="False"></asp:ListBox>
        </p>
        <asp:Button ID="btnCreateLocation" runat="server" Text="Create Location" OnClick="btnCreateLocation_Click" />
        <asp:Button ID="btnLoadLocation" runat="server" OnClick="btnLoadLocation_Click" Text="Load Location" />
        <asp:Button ID="btnViewLocation" runat="server" Text="View Location" OnClick="btnViewLocation_Click" />
        <asp:Button ID="btnDeleteLocation" runat="server" Text="Delete Location" OnClick="btnDeleteLocation_Click" />
        <asp:ListBox ID="lstLocation" runat="server" Visible="False"></asp:ListBox>
        <p>
            <asp:Button ID="btnCreateFrank" runat="server" Text="Create Frank" OnClick="btnCreateFrank_Click" />
            <asp:Button ID="btnLoadFrank" runat="server" OnClick="btnLoadFrank_Click" Text="Load Frank" />
            <asp:Button ID="btnViewFrank" runat="server" Text="View Frank" OnClick="btnViewFrank_Click" />
            <asp:Button ID="btnDeleteFrank" runat="server" Text="Delete Frank" OnClick="btnDeleteFrank_Click" />
            <asp:ListBox ID="lstFrank" runat="server" Visible="False"></asp:ListBox>
        </p>
        <asp:Button ID="btnCreateTerm" runat="server" Text="Create Term" OnClick="btnCreateTerm_Click" />
        <asp:Button ID="btnLoadTerm" runat="server" OnClick="btnLoadTerm_Click" Text="Load Term" />
        <asp:Button ID="btnViewTerm" runat="server" Text="View Term" OnClick="btnViewTerm_Click" />
        <asp:Button ID="btnDeleteTerm" runat="server" Text="Delete Term" OnClick="btnDeleteTerm_Click" />
        <asp:ListBox ID="lstTerm" runat="server" Visible="False"></asp:ListBox>
        <p>
            <asp:Button ID="btnCreateCourseSection" runat="server" Text="Create Course Section" OnClick="btnCreateCourseSection_Click" />
            <asp:Button ID="btnLoadCourseSection" runat="server" OnClick="btnLoadCourseSection_Click" Text="Load Course Section" />
            <asp:Button ID="btnViewCourseSection" runat="server" Text="View Course Section" OnClick="btnViewCourseSection_Click" />
            <asp:Button ID="btnDeleteCourseSection" runat="server" Text="Delete Course Section" OnClick="btnDeleteCourseSection_Click" />
            <asp:ListBox ID="lstCourseSection" runat="server" Visible="False"></asp:ListBox>
        </p>
        <p>
            <asp:Button ID="btnCreateEnrollment" runat="server" Height="22px" Text="Create Enrollment" OnClick="btnCreateEnrollment_Click" />
            <asp:Button ID="btnLoadEnrollment" runat="server" OnClick="btnLoadEnrollment_Click" Text="Load Enrollment" />
            <asp:Button ID="btnViewEnrollment" runat="server" Text="View Enrollment" OnClick="btnViewEnrollment_Click" />
            <asp:Button ID="btnDeleteEnrollment" runat="server" Text="Delete Enrollment" OnClick="btnDeleteEnrollment_Click" />
            <asp:ListBox ID="lstEnrollment" runat="server" Visible="False"></asp:ListBox>
        </p>
        <p>
        <asp:Button ID="btnCreateState" runat="server" Text="Create State" OnClick="btnCreateState_Click" />
        <asp:Button ID="btnLoadState" runat="server" OnClick="btnLoadState_Click" Text="Load State" />
        <asp:Button ID="btnViewState" runat="server" Text="View State" OnClick="btnViewState_Click" />
        <asp:Button ID="btnDeleteState" runat="server" Text="Delete State" OnClick="btnDeleteState_Click" />
        <asp:ListBox ID="lstState" runat="server" Visible="False"></asp:ListBox>
        </p>
    </form>
    <p style="text-align: center">
        &nbsp;</p>
</body>
</html>
