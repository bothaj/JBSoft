<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JBSoft.Web.ViewModels.BaseViewModel>" %>

<% if (Model.HasErrors)
   { %>
       <div class="validation-summary-errors" id="validationServerSummary">
            <% foreach (var error in Model.GetErrors())
               { %><%= Html.Encode(error) %><% } %>
       </div>
<% } %>
<%= Html.ValidationSummary("Please complete the required fields marked with a *") %>