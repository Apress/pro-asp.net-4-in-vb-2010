<%@ Page Language="VB" AutoEventWireup="false"
   CodeFile="PageProcessor.aspx.vb" Inherits="PageProcessor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   <title>LoadPage</title>
   <script type="text/javascript">
      var iLoopCounter = 1;
      var iMaxLoop = 15;
      var iIntervalId;

      function BeginPageLoad() {
         // Redirect the browser to another page while keeping focus.
         location.href = "<%=PageToLoad %>";
         // Update progress meter every 1/2 second.
         iIntervalId =
         window.setInterval(
         "iLoopCounter=UpdateProgressMeter(iLoopCounter,iMaxLoop);", 500
         );
      }
      function UpdateProgressMeter(iCurrentLoopCounter, iMaximumLoops) {
         var progressMeter =
        document.getElementById("ProgressMeter")
         iCurrentLoopCounter += 1;
         if (iCurrentLoopCounter <= iMaximumLoops) {
            progressMeter.innerHTML += ".";
            return iCurrentLoopCounter;
         }
         else {
            progressMeter.innerHTML = "";
            return 1;
         }
      }
      function EndPageLoad() {
         window.clearInterval(iIntervalId);

         // Find the object that represents the progress meter.
         var progressMeter = document.getElementById("ProgressMeter")
         progressMeter.innerHTML = "Page Loaded - Now Transfering";
      }
   </script>
</head>
<body onload="BeginPageLoad();" onunload="EndPageLoad();">
   <form id="frmPageLoader" method="post" runat="server">
   <table border="0" width="99%">
      <tr>
         <td style="vertical-align: middle; text-align: center">
            <span id="MessageText">Loading Page - Please Wait</span>
            <span id="ProgressMeter"></span>
         </td>
      </tr>
   </table>
   </form>
</body>
</html>
