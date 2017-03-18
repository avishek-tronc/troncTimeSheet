<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourceTimeSheet.aspx.cs" Inherits="tronc.Timesheet.Web.ResourceTimeSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name: </td>
                    <td>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Email: </td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Contact: </td>
                    <td>
                        <asp:Label ID="lblContact" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Segment: </td>
                    <td>
                        <asp:Label ID="lblSegment" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Duration: </td>
                    <td>
                        <asp:Label ID="lblDuration" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <div>
                <table border="1">
                    <tr>
                        <td>
                            <b>Date</b>
                        </td>
                        <td>
                            <b>Effort</b>
                        </td>
                        <td>
                            <b>Comments for additional effort</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnFirst" runat="server">1st
                                </span>
                            </b>
                            <asp:HiddenField ID="hdnFirst" runat="server" Value="1" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvfirst" runat="server" ControlToValidate="txtFirst" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnSecond" runat="server">2nd
                                </span>
                            </b>
                            <asp:HiddenField ID="hdnSecond" runat="server" Value="2" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtSecond" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSecond" runat="server" ControlToValidate="txtSecond" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSecondComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnThird" runat="server">3rd
                                </span>
                            </b>
                            <asp:HiddenField ID="hdnThird" runat="server" Value="3" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtThird" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvThird" runat="server" ControlToValidate="txtThird" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtThirdComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnFourth" runat="server">4th

                                </span></b>
                            <asp:HiddenField ID="hdnFourth" runat="server" Value="4" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtFourth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFourth" runat="server" ControlToValidate="txtFourth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFourthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnFifth" runat="server">5th
                                </span>
                            </b>
                             <asp:HiddenField ID="hdnFifth" runat="server" Value="5" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtFifth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFifth" runat="server" ControlToValidate="txtFifth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFifthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnsixth" runat="server">6th
                                   </span></b>
                            <asp:HiddenField ID="hdnsixth" runat="server" Value="6" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtsixth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvsixth" runat="server" ControlToValidate="txtsixth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsixthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnseventh" runat="server">7th
                                    </span></b>
                            <asp:HiddenField ID="hdnseventh" runat="server" Value="7" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtseventh" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvseventh" runat="server" ControlToValidate="txtseventh" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtseventhComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spneighth" runat="server">8th
                                    </span></b>
                            <asp:HiddenField ID="hdneighth" runat="server" Value="8" />
                        </td>
                        <td>
                            <asp:TextBox ID="txteighth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfveighth" runat="server" ControlToValidate="txteighth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txteighthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnnineth" runat="server">9th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdnnineth" runat="server" Value="9" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtnineth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvnineth" runat="server" ControlToValidate="txtnineth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtninethComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <b>
                                <span id="spntenth" runat="server">10th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntenth" runat="server" Value="10" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttenth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtenth" runat="server" ControlToValidate="txttenth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttenthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spneleventh" runat="server">11th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdneleventh" runat="server" Value="11" />
                        </td>
                        <td>
                            <asp:TextBox ID="txteleventh" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfveleventh" runat="server" ControlToValidate="txteleventh" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txteleventhComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnetwelveth" runat="server">12th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwelveth" runat="server" Value="12" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwelveth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwelveth" runat="server" ControlToValidate="txttwelveth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwelvethComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <b>
                                <span id="spntirteenth" runat="server">13th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntirteenth" runat="server" Value="13" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttirteen" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtirteenth" runat="server" ControlToValidate="txttirteen" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttirteenComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <b>
                                <span id="spnfourteenth" runat="server">14th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdnfourteenth" runat="server" Value="14" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtfourteenth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvfourteenth" runat="server" ControlToValidate="txtfourteenth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtfourteenthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <b>
                                <span id="spnfifteenth" runat="server">15th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdnfifteenth" runat="server" Value="15" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtfifteenth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvfifteenth" runat="server" ControlToValidate="txtfifteenth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtfifteenthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <b>
                                <span id="spnsixteenth" runat="server">16th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdnsixteenth" runat="server" Value="16" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtsixteenth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvsixteenth" runat="server" ControlToValidate="txtsixteenth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsixteenthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                     <tr>
                        <td>
                            <b>
                                <span id="spnseventeenth" runat="server">17th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdnseventeenth" runat="server" Value="17" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtseventeenth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvseventeenth" runat="server" ControlToValidate="txtseventeenth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtseventeenthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <b>
                                <span id="spneighteenth" runat="server">18th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdneighteenth" runat="server" Value="18" />
                        </td>
                        <td>
                            <asp:TextBox ID="txteighteenth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxteighteenth" runat="server" ControlToValidate="txteighteenth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txteighteenthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <b>
                                <span id="spnninteenth" runat="server">19th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdnninteenth" runat="server" Value="19" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtninteenth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvninteenth" runat="server" ControlToValidate="txtninteenth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtninteenthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                     <tr>
                        <td>
                            <b>
                                <span id="spntwenty" runat="server">20th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwenty" runat="server" Value="20" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwenty" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwenty" runat="server" ControlToValidate="txttwenty" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <b>
                                <span id="spntwenty1st" runat="server">21th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwenty1st" runat="server" Value="21" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwenty1st" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwenty1st" runat="server" ControlToValidate="txttwenty1st" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwenty1stComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spntwenty2nd" runat="server">22th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwenty2nd" runat="server" Value="22" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwenty2nd" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwenty2nd" runat="server" ControlToValidate="txttwenty2nd" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwenty2ndComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <b>
                                <span id="spntwenty3rd" runat="server">23th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwenty3rd" runat="server" Value="23" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwenty3rd" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwenty3rd" runat="server" ControlToValidate="txttwenty3rd" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwenty3rdComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spntwentyfourth" runat="server">24th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwentyfourth" runat="server" Value="24" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyfourth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwentyfourth" runat="server" ControlToValidate="txttwentyfourth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyfourthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spntwentyfifth" runat="server">25th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwentyfifth" runat="server" Value="25" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyfifth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwentyfifth" runat="server" ControlToValidate="txttwentyfifth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyfifthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                     <tr>
                        <td>
                            <b>
                                <span id="spntwentysixth" runat="server">26th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwentysixth" runat="server" Value="26" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentysixth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwentysixth" runat="server" ControlToValidate="txttwentysixth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentysixthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <b>
                                <span id="spntwentyseventh" runat="server">27th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwentyseventh" runat="server" Value="27" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyseventh" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwentyseventh" runat="server" ControlToValidate="txttwentyseventh" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyseventhComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <b>
                                <span id="spntwentyeighth" runat="server">28th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwentyeighth" runat="server" Value="28" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyeighth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwentyeighth" runat="server" ControlToValidate="txttwentyeighth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyeighthComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <b>
                                <span id="spntwentynineth" runat="server">29th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdntwentynineth" runat="server" Value="29" />
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentynineth" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtwentynineth" runat="server" ControlToValidate="txttwentynineth" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttwentyninethComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <span id="spnthirty" runat="server">30th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdnthirty" runat="server" Value="30" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtthirty" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvthirty" runat="server" ControlToValidate="txtthirty" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtthirtyComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <b>
                                <span id="spnthirtyone" runat="server">31th
                                    &nbsp;</span></b>
                            <asp:HiddenField ID="hdnthirtyone" runat="server" Value="31" />
                        </td>
                        <td>
                            <asp:TextBox ID="txthirtyone" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvthirtyone" runat="server" ControlToValidate="txthirtyone" ValidationGroup="grpEffort" ErrorMessage="Please Enter Effort"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtthirtyoneComment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>

            </div>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="grpEffort" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
