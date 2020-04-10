<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="WebApplication9.DefaultPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment</title>
    <script type="text/javascript">          
    </script>
    <style type="text/css">

        body{
            /*background-image:url("https://spiderimg.itstrendingnow.com/assets/images/2017/08/31/750x506/chankya_1504151061.jpeg");*/            
            background-repeat:no-repeat;
            background-size:cover;
        }
        .auto-style3 {
            width: 232px;
        }
        .auto-style4 {
            width: 75%;
            height: 89px;
        }
        .auto-style5 {
            width: 337px;
        }
        .auto-style6 {
            width: 139px;
            height: 30px;
        }
        .auto-style7 {
            width: 232px;
            height: 30px;
        }
        .auto-style8 {
            width: 337px;
            height: 30px;
        }
        .auto-style9 {
            width: 139px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style4">
                <tr>
                    <th class="auto-style9"></th>
                    <th class="auto-style3">Student Information</th>
                    <td class="auto-style5">&nbsp;<%--<asp:Button ID="RedirectBtn" runat="server" Text="Goto Cascaded DropDown Page" CausesValidation="False" OnClick="RedirectBtn_Click" Height="25px" />--%></td>
                </tr>
                <tr>
                    <td class="auto-style9">Enter Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Name" runat="server" Width="227px"></asp:TextBox>
                        <asp:DropDownList ID="Names" AutoPostBack="true" runat="server" Visible="false" Height="25px" OnSelectedIndexChanged="Names_SelectedIndexChanged" Width="235px"></asp:DropDownList>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name" ForeColor="Red" ErrorMessage="Enter your Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Enter Age</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Age" runat="server" Width="227px" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Age" ForeColor="Red" ErrorMessage="Enter your Age" Display="Dynamic"></asp:RequiredFieldValidator>                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Enter Email</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Email" runat="server" Width="227px" TextMode="Email"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="Email" ErrorMessage="Enter your valid Email"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Enter Password</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Password" runat="server" Width="227px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Password" ForeColor="Red" ErrorMessage="Please enter your valid password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Re-enter password</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="RePassword" runat="server" Width="227px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter The Password again" ForeColor="Red" ControlToValidate="RePassword" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToValidate="RePassword" ControlToCompare="Password" ErrorMessage="The Passwords do not Match"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Select Gender</td>
                    <td class="auto-style3">
                        <asp:RadioButtonList ID="Gender" runat="server" Width="232px">
                            <asp:ListItem Value="0">Male</asp:ListItem>
                            <asp:ListItem Value="1">Female</asp:ListItem>
                            <asp:ListItem Value="2">Others</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style5">                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Select Hobbies</td>
                    <td class="auto-style3">
                        <asp:CheckBoxList ID="Hobbies" runat="server" Width="228px">
                            <asp:ListItem>Reading</asp:ListItem>
                            <asp:ListItem>Skating</asp:ListItem>
                            <asp:ListItem>Dancing</asp:ListItem>
                            <asp:ListItem>Others</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td class="auto-style5">                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="178px" />
                        <asp:Button ID="ImgDisplayBtn" runat="server" CausesValidation="False" OnClick="ImgDisplayBtn_Click" Text="Show Image" Width="177px" />
                    </td>
                    <td class="auto-style3">
                        <asp:Image ID="Image1" runat="server" Height="120px" Width="223px" />
                    </td>
                    <td class="auto-style5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style3">
                        <asp:Button ID="AddStudentBtn" runat="server" Text="Add Student Object" OnClick="AddStudentBtn_Click" Width="216px" CausesValidation="False" ValidateRequestMode="Disabled" />
                        &nbsp;
                        </td>
                    <td class="auto-style5">
                        <asp:Button ID="ExitModeBtn" runat="server" Text="Exit Display Mode" CausesValidation="False" OnClick="ExitModeBtn_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style7">
                        <asp:Button ID="ValidateBtn" runat="server" Text="Validate" OnClick="ValidateBtn_Click" Width="218px" />
                        &nbsp;&nbsp;&nbsp;</td>
                    <td class="auto-style8"><asp:Button ID="Button4" runat="server" Text="Save Record" OnClick="Button4_Click" Width="109px" />
                    </td>
                </tr>
            </table>            
        </div>
    </form>
</body>
</html>