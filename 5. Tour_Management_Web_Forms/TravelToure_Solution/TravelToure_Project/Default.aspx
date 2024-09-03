<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TravelToure_Project.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .box{
            width: 1000px;
            height: 500px;
            margin: 40px auto;
            color: rgb(128, 128, 128);
        }
        .b1{
            display: flex;
            margin-top: 20px;
            gap: 35px;

            
        }
        .tx1{
            margin-top: 90px;
        }
        .tx2{
            padding-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    <div class="box">
            <div  >
               <div Class="text-center">
                <h1>MIH Tour Management System (ASP .NET Web Form) </h1>
                <h2  class="tx2">IsBD-BISEW Graduate IT Scholarship</h2>
                <h3  class="tx2">Professional Diploma In .NET Using C#</h3>
                <h4>Round-52</h4>
            <hr/>
            <div class="b1">
                <div class="tx1">
                    <h4 class="tx2">Project Created By:<strong> MD. Iquball Hossain</strong> </h4>
                    <h4 class="tx2">Trainee ID: <strong>1270381</strong> </h4>
                    <h4 class="tx2">Batch:<strong> CS/ACSL-M/52/01 </strong> </h4>
                </div>
                <div><img style="width:300px" src="mih.jpg" alt=""></div>
            </div>
         </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
