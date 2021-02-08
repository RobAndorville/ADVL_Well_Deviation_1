Public Class frmGetCRSList
    'Form used to get the list of Geographic and Projected coordinate reference systems

#Region " Variable Declarations - All the variables used in this form and this application." '-------------------------------------------------------------------------------------------------

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Properties - All the properties used in this form and this application" '------------------------------------------------------------------------------------------------------------

    Private _northLat As Single 'The north bounding latitude in decimal degrees
    Property NorthLat As Single
        Get
            Return _northLat
        End Get
        Set(value As Single)
            _northLat = value
        End Set
    End Property

    Private _SouthLat As Single
    Property SouthLat As Single
        Get
            Return _SouthLat
        End Get
        Set(value As Single)
            _SouthLat = value
        End Set
    End Property

    Private _westLong As Single
    Property WestLong As Single
        Get
            Return _westLong
        End Get
        Set(value As Single)
            _westLong = value
        End Set
    End Property

    Private _eastLong As Single
    Property EastLong As Single
        Get
            Return _eastLong
        End Get
        Set(value As Single)
            _eastLong = value
        End Set
    End Property




#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Process XML files - Read and write XML files." '-------------------------------------------------------------------------------------------------------------------------------------

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.
        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <FormSettings>
                               <Left><%= Me.Left %></Left>
                               <Top><%= Me.Top %></Top>
                               <Width><%= Me.Width %></Width>
                               <Height><%= Me.Height %></Height>
                               <!---->
                               <GetGeographic2D><%= chkGeographic2D.Checked %></GetGeographic2D>
                               <GetGeographic3D><%= chkGeographic3D.Checked %></GetGeographic3D>
                               <GetAll><%= rbGetAll.Checked %></GetAll>
                               <GetExtendingInto><%= rbExtendingInto.Checked %></GetExtendingInto>
                               <GetInside><%= rbInside.Checked %></GetInside>
                               <SelectionAreaName><%= txtAreaOfUseName.Text %></SelectionAreaName>
                               <NorthLatitude><%= NorthLat %></NorthLatitude>
                               <SouthLatitude><%= SouthLat %></SouthLatitude>
                               <WestLongitude><%= WestLong %></WestLongitude>
                               <EastLongitude><%= EastLong %></EastLongitude>
                               <!---->
                               <NorthLatDeg><%= txtNLatDegrees.Text %></NorthLatDeg>
                               <NorthLatMin><%= txtNLatMinutes.Text %></NorthLatMin>
                               <NorthLatSec><%= txtNLatSeconds.Text %></NorthLatSec>
                               <NorthLatNS><%= cmbNLatNS.SelectedItem.ToString %></NorthLatNS>
                               <!---->
                               <SouthLatDeg><%= txtSLatDegrees.Text %></SouthLatDeg>
                               <SouthLatMin><%= txtSLatMinutes.Text %></SouthLatMin>
                               <SouthLatSec><%= txtSLatSeconds.Text %></SouthLatSec>
                               <SouthLatNS><%= cmbSLatNS.SelectedItem.ToString %></SouthLatNS>
                               <!---->
                               <WestLongDeg><%= txtWLongDegrees.Text %></WestLongDeg>
                               <WestLongMin><%= txtWLongMinutes.Text %></WestLongMin>
                               <WestLongSec><%= txtWLongSeconds.Text %></WestLongSec>
                               <WestLongWE><%= cmbWLongWE.SelectedItem.ToString %></WestLongWE>
                               <!---->
                               <EastLongDeg><%= txtELongDegrees.Text %></EastLongDeg>
                               <EastLongMin><%= txtELongMinutes.Text %></EastLongMin>
                               <EastLongSec><%= txtELongSeconds.Text %></EastLongSec>
                               <EastLongWE><%= cmbELongWE.SelectedItem.ToString %></EastLongWE>
                           </FormSettings>

        'Add code to include other settings to save after the comment line <!---->

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Main.Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        Dim SettingsFileName As String = "FormSettings_" & Main.ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Main.Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Main.Project.ReadXmlSettings(SettingsFileName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore form position and size:
            If Settings.<FormSettings>.<Left>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Left = Settings.<FormSettings>.<Left>.Value
            End If

            If Settings.<FormSettings>.<Top>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Top = Settings.<FormSettings>.<Top>.Value
            End If

            If Settings.<FormSettings>.<Height>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Height = Settings.<FormSettings>.<Height>.Value
            End If

            If Settings.<FormSettings>.<Width>.Value = Nothing Then
                'Form setting not saved.
            Else
                Me.Width = Settings.<FormSettings>.<Width>.Value
            End If

            'Add code to read other saved setting here:
            If Settings.<FormSettings>.<GetGeographic2D>.Value <> Nothing Then chkGeographic2D.Checked = Settings.<FormSettings>.<GetGeographic2D>.Value
            If Settings.<FormSettings>.<GetGeographic3D>.Value <> Nothing Then chkGeographic3D.Checked = Settings.<FormSettings>.<GetGeographic3D>.Value
            If Settings.<FormSettings>.<GetAll>.Value <> Nothing Then rbGetAll.Checked = Settings.<FormSettings>.<GetAll>.Value
            If Settings.<FormSettings>.<GetExtendingInto>.Value <> Nothing Then rbExtendingInto.Checked = Settings.<FormSettings>.<GetExtendingInto>.Value
            If Settings.<FormSettings>.<GetInside>.Value <> Nothing Then rbInside.Checked = Settings.<FormSettings>.<GetInside>.Value
            If Settings.<FormSettings>.<SelectionAreaName>.Value <> Nothing Then txtAreaOfUseName.Text = Settings.<FormSettings>.<SelectionAreaName>.Value
            If Settings.<FormSettings>.<NorthLatitude>.Value <> Nothing Then NorthLat = Settings.<FormSettings>.<NorthLatitude>.Value
            If Settings.<FormSettings>.<SouthLatitude>.Value <> Nothing Then SouthLat = Settings.<FormSettings>.<SouthLatitude>.Value
            If Settings.<FormSettings>.<WestLongitude>.Value <> Nothing Then WestLong = Settings.<FormSettings>.<WestLongitude>.Value
            If Settings.<FormSettings>.<EastLongitude>.Value <> Nothing Then EastLong = Settings.<FormSettings>.<EastLongitude>.Value

            If Settings.<FormSettings>.<NorthLatDeg>.Value <> Nothing Then txtNLatDegrees.Text = Settings.<FormSettings>.<NorthLatDeg>.Value
            If Settings.<FormSettings>.<NorthLatMin>.Value <> Nothing Then txtNLatMinutes.Text = Settings.<FormSettings>.<NorthLatMin>.Value
            If Settings.<FormSettings>.<NorthLatSec>.Value <> Nothing Then txtNLatSeconds.Text = Settings.<FormSettings>.<NorthLatSec>.Value
            If Settings.<FormSettings>.<NorthLatNS>.Value <> Nothing Then cmbNLatNS.SelectedIndex = cmbNLatNS.FindStringExact(Settings.<FormSettings>.<NorthLatNS>.Value)

            If Settings.<FormSettings>.<SouthLatDeg>.Value <> Nothing Then txtSLatDegrees.Text = Settings.<FormSettings>.<SouthLatDeg>.Value
            If Settings.<FormSettings>.<SouthLatMin>.Value <> Nothing Then txtSLatMinutes.Text = Settings.<FormSettings>.<SouthLatMin>.Value
            If Settings.<FormSettings>.<SouthLatSec>.Value <> Nothing Then txtSLatSeconds.Text = Settings.<FormSettings>.<SouthLatSec>.Value
            If Settings.<FormSettings>.<SouthLatNS>.Value <> Nothing Then cmbSLatNS.SelectedIndex = cmbSLatNS.FindStringExact(Settings.<FormSettings>.<SouthLatNS>.Value)

            If Settings.<FormSettings>.<WestLongDeg>.Value <> Nothing Then txtWLongDegrees.Text = Settings.<FormSettings>.<WestLongDeg>.Value
            If Settings.<FormSettings>.<WestLongMin>.Value <> Nothing Then txtWLongMinutes.Text = Settings.<FormSettings>.<WestLongMin>.Value
            If Settings.<FormSettings>.<WestLongSec>.Value <> Nothing Then txtWLongSeconds.Text = Settings.<FormSettings>.<WestLongSec>.Value
            If Settings.<FormSettings>.<WestLongNS>.Value <> Nothing Then cmbWLongWE.SelectedIndex = cmbWLongWE.FindStringExact(Settings.<FormSettings>.<WestLongNS>.Value)

            If Settings.<FormSettings>.<EastLongDeg>.Value <> Nothing Then txtELongDegrees.Text = Settings.<FormSettings>.<EastLongDeg>.Value
            If Settings.<FormSettings>.<EastLongMin>.Value <> Nothing Then txtELongMinutes.Text = Settings.<FormSettings>.<EastLongMin>.Value
            If Settings.<FormSettings>.<EastLongSec>.Value <> Nothing Then txtELongSeconds.Text = Settings.<FormSettings>.<EastLongSec>.Value
            If Settings.<FormSettings>.<EastLongNS>.Value <> Nothing Then cmbELongWE.SelectedIndex = cmbELongWE.FindStringExact(Settings.<FormSettings>.<EastLongNS>.Value)
            CheckFormPos()
        End If
    End Sub

    Private Sub CheckFormPos()
        'Chech that the form can be seen on a screen.

        Dim MinWidthVisible As Integer = 192 'Minimum number of X pixels visible. The form will be moved if this many form pixels are not visible.
        Dim MinHeightVisible As Integer = 64 'Minimum number of Y pixels visible. The form will be moved if this many form pixels are not visible.

        Dim FormRect As New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
        Dim WARect As Rectangle = Screen.GetWorkingArea(FormRect) 'The Working Area rectangle - the usable area of the screen containing the form.

        ''Check if the top of the form is less than zero:
        'If Me.Top < 0 Then Me.Top = 0

        'Check if the top of the form is above the top of the Working Area:
        If Me.Top < WARect.Top Then
            Me.Top = WARect.Top
        End If

        'Check if the top of the form is too close to the bottom of the Working Area:
        If (Me.Top + MinHeightVisible) > (WARect.Top + WARect.Height) Then
            Me.Top = WARect.Top + WARect.Height - MinHeightVisible
        End If

        'Check if the left edge of the form is too close to the right edge of the Working Area:
        If (Me.Left + MinWidthVisible) > (WARect.Left + WARect.Width) Then
            Me.Left = WARect.Left + WARect.Width - MinWidthVisible
        End If

        'Check if the right edge of the form is too close to the left edge of the Working Area:
        If (Me.Left + Me.Width - MinWidthVisible) < WARect.Left Then
            Me.Left = WARect.Left - Me.Width + MinWidthVisible
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message) 'Save the form settings before the form is minimised:
        If m.Msg = &H112 Then 'SysCommand
            If m.WParam.ToInt32 = &HF020 Then 'Form is being minimised
                SaveFormSettings()
            End If
        End If
        MyBase.WndProc(m)
    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load


        cmbELongWE.Items.Add("W")
        cmbELongWE.Items.Add("E")
        cmbELongWE.SelectedIndex = 1 'Select "E"

        cmbWLongWE.Items.Add("W")
        cmbWLongWE.Items.Add("E")
        cmbWLongWE.SelectedIndex = 1 'Select "E"

        cmbNLatNS.Items.Add("N")
        cmbNLatNS.Items.Add("S")
        cmbNLatNS.SelectedIndex = 0 'Select "N"

        cmbSLatNS.Items.Add("N")
        cmbSLatNS.Items.Add("S")
        cmbSLatNS.SelectedIndex = 0 'Select "N"

        chkGeographic2D.Checked = True 'Default: Get Geographic 2D CRSs
        chkGeographic3D.Checked = False
        rbGetAll.Checked = True 'Default: Get All CRSs

        RestoreFormSettings()   'Restore the form settings



    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Form
        Me.Close() 'Close the form
    End Sub

    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        Else
            'Dont save settings if form is minimised.
        End If
    End Sub



#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------

#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Private Sub btnPasteFromClipboard_Click(sender As Object, e As EventArgs) Handles btnPasteFromClipboard.Click
        'Paste Area of Use from clipboard

        Try
            Dim AreaXDoc As System.Xml.Linq.XDocument = XDocument.Parse(My.Computer.Clipboard.GetText)



            If IsNothing(AreaXDoc) Then
                Main.Message.Add("No Area of Use data in clipboard.")
                Exit Sub
            End If

            If AreaXDoc.<XMsg>.<AreaOfUse>.<AreaName>.Value = Nothing Then
                txtAreaOfUseName.Text = ""
            Else
                txtAreaOfUseName.Text = AreaXDoc.<XMsg>.<AreaOfUse>.<AreaName>.Value
            End If

            If AreaXDoc.<XMsg>.<AreaOfUse>.<NorthLatitude>.Value = Nothing Then
                NorthLat = 0
            Else
                NorthLat = AreaXDoc.<XMsg>.<AreaOfUse>.<NorthLatitude>.Value
            End If

            If AreaXDoc.<XMsg>.<AreaOfUse>.<SouthLatitude>.Value = Nothing Then
                SouthLat = 0
            Else
                SouthLat = AreaXDoc.<XMsg>.<AreaOfUse>.<SouthLatitude>.Value
            End If

            If AreaXDoc.<XMsg>.<AreaOfUse>.<WestLongitude>.Value = Nothing Then
                WestLong = 0
            Else
                WestLong = AreaXDoc.<XMsg>.<AreaOfUse>.<WestLongitude>.Value
            End If

            If AreaXDoc.<XMsg>.<AreaOfUse>.<EastLongitude>.Value = Nothing Then
                EastLong = 0
            Else
                EastLong = AreaXDoc.<XMsg>.<AreaOfUse>.<EastLongitude>.Value
            End If

            UpdateBounds()

        Catch ex As Exception
            Main.Message.SetWarningStyle()
            Main.Message.Add("Error pasting from clipboard: " & ex.Message & vbCrLf)
            Main.Message.SetNormalStyle()
        End Try

    End Sub

    'Private Sub UpdateBounds_Old()
    Private Sub UpdateBounds()
        'Send instructions to the Coordinars application to convert boundary decimal degrees to degrees, minutes and seconds.

        'Create the xml instructions
        Dim decl As New XDeclaration("1.0", "utf-8", "yes")
        Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
        Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class

        'ADDED 3Feb19:
        'Dim clientAppNetName As New XElement("ClientAppNetName", Main.AppNetName)
        'xmessage.Add(clientAppNetName)
        Dim clientProNetName As New XElement("ClientProNetName", Main.ProNetName)
        xmessage.Add(clientProNetName)

        Dim clientName As New XElement("ClientName", Main.ApplicationInfo.Name) 'This tells the coordinate server the name of the client making the request.
        xmessage.Add(clientName)

        'Convert North Latitude:
        Dim clientLocn As New XElement("ClientLocn", "GetCRSList_NorthLat")
        xmessage.Add(clientLocn)
        Dim operation As New XElement("ConvertAngle")
        Dim inputAngle As New XElement("InputDecimalDegrees", NorthLat)
        operation.Add(inputAngle)

        'Dim outputDmsSignName As New XElement("OutputDmsSignLocn", "NorthLatDmsSign")
        'operation.Add(outputDmsSignName)
        'Dim outputDmsDegreesName As New XElement("OutputDmsDegreesLocn", "NorthLatDmsDegrees")
        'operation.Add(outputDmsDegreesName)
        'Dim outputDmsMinutesName As New XElement("OutputDmsMinutesLocn", "NorthLatDmsMinutes")
        'operation.Add(outputDmsMinutesName)
        'Dim outputDmsSecondsName As New XElement("OutputDmsSecondsLocn", "NorthLatDmsSeconds")
        'operation.Add(outputDmsSecondsName)
        Dim command As New XElement("Command", "ConvertDecimalDegreesToDms")
        operation.Add(command)
        xmessage.Add(operation)

        'Add operations to convert SouthLat, WestLong and EastLong.

        'Convert South Latitude:
        Dim clientLocn2 As New XElement("ClientLocn", "GetCRSList_SouthLat")
        xmessage.Add(clientLocn2)
        Dim operation2 As New XElement("ConvertAngle")
        Dim inputAngle2 As New XElement("InputDecimalDegrees", SouthLat)
        operation2.Add(inputAngle2)

        'Dim outputDmsSignName2 As New XElement("OutputDmsSignLocn", "SouthLatDmsSign")
        'operation2.Add(outputDmsSignName2)
        'Dim outputDmsDegreesName2 As New XElement("OutputDmsDegreesLocn", "SouthLatDmsDegrees")
        'operation2.Add(outputDmsDegreesName2)
        'Dim outputDmsMinutesName2 As New XElement("OutputDmsMinutesLocn", "SouthLatDmsMinutes")
        'operation2.Add(outputDmsMinutesName2)
        'Dim outputDmsSecondsName2 As New XElement("OutputDmsSecondsLocn", "SouthLatDmsSeconds")
        'operation2.Add(outputDmsSecondsName2)
        Dim command2 As New XElement("Command", "ConvertDecimalDegreesToDms")
        operation2.Add(command2)
        xmessage.Add(operation2)

        'Convert West Longitude:
        Dim clientLocn3 As New XElement("ClientLocn", "GetCRSList_WestLong")
        xmessage.Add(clientLocn3)
        Dim operation3 As New XElement("ConvertAngle")
        Dim inputAngle3 As New XElement("InputDecimalDegrees", WestLong)
        operation3.Add(inputAngle3)

        'Dim outputDmsSignName3 As New XElement("OutputDmsSignLocn", "WestLongDmsSign")
        'operation3.Add(outputDmsSignName3)
        'Dim outputDmsDegreesName3 As New XElement("OutputDmsDegreesLocn", "WestLongDmsDegrees")
        'operation3.Add(outputDmsDegreesName3)
        'Dim outputDmsMinutesName3 As New XElement("OutputDmsMinutesLocn", "WestLongDmsMinutes")
        'operation3.Add(outputDmsMinutesName3)
        'Dim outputDmsSecondsName3 As New XElement("OutputDmsSecondsLocn", "WestLongDmsSeconds")
        'operation3.Add(outputDmsSecondsName3)
        Dim command3 As New XElement("Command", "ConvertDecimalDegreesToDms")
        operation3.Add(command3)
        xmessage.Add(operation3)

        'Convert East Longitude:
        Dim clientLocn4 As New XElement("ClientLocn", "GetCRSList_EastLong")
        xmessage.Add(clientLocn4)
        Dim operation4 As New XElement("ConvertAngle")
        Dim inputAngle4 As New XElement("InputDecimalDegrees", EastLong)
        operation4.Add(inputAngle4)

        'Dim outputDmsSignName4 As New XElement("OutputDmsSignLocn", "EastLongDmsSign")
        'operation4.Add(outputDmsSignName4)
        'Dim outputDmsDegreesName4 As New XElement("OutputDmsDegreesLocn", "EastLongDmsDegrees")
        'operation4.Add(outputDmsDegreesName4)
        'Dim outputDmsMinutesName4 As New XElement("OutputDmsMinutesLocn", "EastLongDmsMinutes")
        'operation4.Add(outputDmsMinutesName4)
        'Dim outputDmsSecondsName4 As New XElement("OutputDmsSecondsLocn", "EastLongDmsSeconds")
        'operation4.Add(outputDmsSecondsName4)
        Dim command4 As New XElement("Command", "ConvertDecimalDegreesToDms")
        operation4.Add(command4)
        xmessage.Add(operation4)

        doc.Add(xmessage)

        'Send the instructions to the Coordinates application:
        If IsNothing(Main.client) Then
            Main.Message.Add("No client connection available!" & vbCrLf)
        Else
            If Main.client.State = ServiceModel.CommunicationState.Faulted Then
                Main.Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                'Main.client.SendMessageAsync("ADVL_Coordinates_1", doc.ToString)
                'Main.client.SendMessageAsync(Main.AppNetName, "ADVL_Coordinates_1", doc.ToString)
                Main.client.SendMessageAsync(Main.ProNetName, "ADVL_Coordinates_1", doc.ToString)
                'Main.Message.Color = Color.Red
                'Main.Message.FontStyle = FontStyle.Bold
                'Main.Message.XAdd("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf)
                'Main.Message.SetNormalStyle()
                'Main.Message.XAdd(doc.ToString & vbCrLf & vbCrLf)
                'Main.Message.XAddText("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf, "XmlSentNotice")
                Main.Message.XAddText("Message sent to [" & Main.ProNetName & "]." & "ADVL_Coordinates_1" & ":" & vbCrLf, "XmlSentNotice")
                Main.Message.XAddXml(doc.ToString)
                Main.Message.XAddText(vbCrLf, "Normal") 'Add extra line
            End If
        End If

    End Sub

    Private Sub UpdateBounds_Old2()
        'Send instructions to the Coordinars application to convert boundary decimal degrees to degrees, minutes and seconds.

        'UpdateNorthLat()
        'Application.DoEvents()
        'UpdateSouthLat()
        'Application.DoEvents()
        'UpdateWestLong()
        'Application.DoEvents()
        'UpdateEastLong()
    End Sub

    'Private Sub UpdateNorthLat()
    '    'Send instructions to the Coordinates application to convert the North Latitude decimal degrees to degrees, minutes and seconds.

    '    'Create the xml instructions
    '    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
    '    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
    '    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
    '    Dim clientName As New XElement("ClientName", Main.ApplicationInfo.Name) 'This tells the coordinate server the name of the client making the request.
    '    xmessage.Add(clientName)

    '    'Convert North Latitude:
    '    Dim clientLocn As New XElement("ClientLocn", "GetCRSList_NorthLat")
    '    xmessage.Add(clientLocn)
    '    Dim operation As New XElement("ConvertAngle")
    '    Dim inputAngle As New XElement("InputDecimalDegrees", NorthLat)
    '    operation.Add(inputAngle)

    '    Dim command As New XElement("Command", "ConvertDecimalDegreesToDms")
    '    operation.Add(command)
    '    xmessage.Add(operation)

    '    doc.Add(xmessage)

    '    'Send the instructions to the Coordinates application:
    '    If IsNothing(Main.client) Then
    '        Main.Message.Add("No client connection available!" & vbCrLf)
    '    Else
    '        If Main.client.State = ServiceModel.CommunicationState.Faulted Then
    '            Main.Message.Add("client state is faulted. Message not sent!" & vbCrLf)
    '        Else
    '            Main.client.SendMessageAsync("ADVL_Coordinates_1", doc.ToString)
    '            Main.Message.Color = Color.Red
    '            Main.Message.FontStyle = FontStyle.Bold
    '            Main.Message.XAdd("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf)
    '            Main.Message.SetNormalStyle()
    '            Main.Message.XAdd(doc.ToString & vbCrLf & vbCrLf)
    '        End If
    '    End If

    'End Sub

    'Private Sub UpdateSouthLat()
    '    'Send instructions to the Coordinates application to convert the South Latitude decimal degrees to degrees, minutes and seconds.

    '    'Create the xml instructions
    '    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
    '    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
    '    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
    '    Dim clientName As New XElement("ClientName", Main.ApplicationInfo.Name) 'This tells the coordinate server the name of the client making the request.
    '    xmessage.Add(clientName)

    '    'Convert North Latitude:
    '    Dim clientLocn As New XElement("ClientLocn", "GetCRSList_SouthLat")
    '    xmessage.Add(clientLocn)
    '    Dim operation As New XElement("ConvertAngle")
    '    Dim inputAngle As New XElement("InputDecimalDegrees", SouthLat)
    '    operation.Add(inputAngle)

    '    Dim command As New XElement("Command", "ConvertDecimalDegreesToDms")
    '    operation.Add(command)
    '    xmessage.Add(operation)

    '    doc.Add(xmessage)

    '    'Send the instructions to the Coordinates application:
    '    If IsNothing(Main.client) Then
    '        Main.Message.Add("No client connection available!" & vbCrLf)
    '    Else
    '        If Main.client.State = ServiceModel.CommunicationState.Faulted Then
    '            Main.Message.Add("client state is faulted. Message not sent!" & vbCrLf)
    '        Else
    '            Main.client.SendMessageAsync("ADVL_Coordinates_1", doc.ToString)
    '            Main.Message.Color = Color.Red
    '            Main.Message.FontStyle = FontStyle.Bold
    '            Main.Message.XAdd("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf)
    '            Main.Message.SetNormalStyle()
    '            Main.Message.XAdd(doc.ToString & vbCrLf & vbCrLf)
    '        End If
    '    End If
    'End Sub

    'Private Sub UpdateWestLong()
    '    'Send instructions to the Coordinates application to convert the West Longitude decimal degrees to degrees, minutes and seconds.

    '    'Create the xml instructions
    '    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
    '    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
    '    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
    '    Dim clientName As New XElement("ClientName", Main.ApplicationInfo.Name) 'This tells the coordinate server the name of the client making the request.
    '    xmessage.Add(clientName)

    '    'Convert North Latitude:
    '    Dim clientLocn As New XElement("ClientLocn", "GetCRSList_WestLong")
    '    xmessage.Add(clientLocn)
    '    Dim operation As New XElement("ConvertAngle")
    '    Dim inputAngle As New XElement("InputDecimalDegrees", WestLong)
    '    operation.Add(inputAngle)

    '    Dim command As New XElement("Command", "ConvertDecimalDegreesToDms")
    '    operation.Add(command)
    '    xmessage.Add(operation)

    '    doc.Add(xmessage)

    '    'Send the instructions to the Coordinates application:
    '    If IsNothing(Main.client) Then
    '        Main.Message.Add("No client connection available!" & vbCrLf)
    '    Else
    '        If Main.client.State = ServiceModel.CommunicationState.Faulted Then
    '            Main.Message.Add("client state is faulted. Message not sent!" & vbCrLf)
    '        Else
    '            Main.client.SendMessageAsync("ADVL_Coordinates_1", doc.ToString)
    '            Main.Message.Color = Color.Red
    '            Main.Message.FontStyle = FontStyle.Bold
    '            Main.Message.XAdd("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf)
    '            Main.Message.SetNormalStyle()
    '            Main.Message.XAdd(doc.ToString & vbCrLf & vbCrLf)
    '        End If
    '    End If
    'End Sub

    'Private Sub UpdateEastLong()
    '    'Send instructions to the Coordinates application to convert the East Longitude decimal degrees to degrees, minutes and seconds.

    '    'Create the xml instructions
    '    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
    '    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
    '    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
    '    Dim clientName As New XElement("ClientName", Main.ApplicationInfo.Name) 'This tells the coordinate server the name of the client making the request.
    '    xmessage.Add(clientName)

    '    'Convert North Latitude:
    '    Dim clientLocn As New XElement("ClientLocn", "GetCRSList_EastLong")
    '    xmessage.Add(clientLocn)
    '    Dim operation As New XElement("ConvertAngle")
    '    Dim inputAngle As New XElement("InputDecimalDegrees", EastLong)
    '    operation.Add(inputAngle)

    '    Dim command As New XElement("Command", "ConvertDecimalDegreesToDms")
    '    operation.Add(command)
    '    xmessage.Add(operation)

    '    doc.Add(xmessage)

    '    'Send the instructions to the Coordinates application:
    '    If IsNothing(Main.client) Then
    '        Main.Message.Add("No client connection available!" & vbCrLf)
    '    Else
    '        If Main.client.State = ServiceModel.CommunicationState.Faulted Then
    '            Main.Message.Add("client state is faulted. Message not sent!" & vbCrLf)
    '        Else
    '            Main.client.SendMessageAsync("ADVL_Coordinates_1", doc.ToString)
    '            Main.Message.Color = Color.Red
    '            Main.Message.FontStyle = FontStyle.Bold
    '            Main.Message.XAdd("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf)
    '            Main.Message.SetNormalStyle()
    '            Main.Message.XAdd(doc.ToString & vbCrLf & vbCrLf)
    '        End If
    '    End If
    'End Sub

    Private Sub btnGetGeoCRSList_Click(sender As Object, e As EventArgs) Handles btnGetGeoCRSList.Click
        'Send instructions to the Coordinates application to get a list of Geographic coordinate reference systems.

        'Create the xml instructions
        Dim decl As New XDeclaration("1.0", "utf-8", "yes")
        Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
        Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
        'Dim clientName As New XElement("ClientName", Main.ApplicationInfo.Name) 'This tells the coordinate server the name of the client making the request.
        'xmessage.Add(clientName)

        'ADDED 3Feb19:
        'Dim clientAppNetName As New XElement("ClientAppNetName", Main.AppNetName)
        'xmessage.Add(clientAppNetName)
        Dim clientProNetName As New XElement("ClientProNetName", Main.ProNetName)
        xmessage.Add(clientProNetName)

        Dim clientConnName As New XElement("ClientConnectionName", Main.ConnectionName) 'This tells the coordinate server the name of the client making the request.
        xmessage.Add(clientConnName)

        'Specifications for the Geographic CRS list.:
        Dim operation As New XElement("GetGeographicCRSList")

        If rbGetAll.Checked Then 'Get all the Geographic CRSs
            Dim SelectMethod As New XElement("SelectMethod", "All")
            operation.Add(SelectMethod)
        Else 'Get Geographic CRSs within specified boundaries.
            Dim NorthLatitude As New XElement("NorthLatitude", NorthLat)
            operation.Add(NorthLatitude)
            Dim SouthLatitude As New XElement("SouthLatitude", SouthLat)
            operation.Add(SouthLatitude)
            Dim WestLongitude As New XElement("WestLongitude", WestLong)
            operation.Add(WestLongitude)
            Dim EastLongitude As New XElement("EastLongitude", EastLong)
            operation.Add(EastLongitude)
            If rbExtendingInto.Checked Then
                Dim SelectMethod As New XElement("SelectMethod", "ExtendingInto")
                operation.Add(SelectMethod)
            ElseIf rbInside.Checked Then
                Dim SelectMethod As New XElement("SelectMethod", "Inside")
                operation.Add(SelectMethod)
            Else
                'Error
                Main.Message.SetWarningStyle()
                Main.Message.Add("Geographic CRS selection error. No selection criteria specified." & vbCrLf)
                Main.Message.SetNormalStyle()
                Exit Sub
            End If
        End If

        If chkGeographic2D.Checked Then
            Dim GetGeographic2D As New XElement("GetGeographic2D", "true")
            operation.Add(GetGeographic2D)
        Else
            Dim GetGeographic2D As New XElement("GetGeographic2D", "false")
            operation.Add(GetGeographic2D)
        End If

        If chkGeographic3D.Checked Then
            Dim GetGeographic3D As New XElement("GetGeographic3D", "true")
            operation.Add(GetGeographic3D)
        Else
            Dim GetGeographic3D As New XElement("GetGeographic3D", "false")
            operation.Add(GetGeographic3D)
        End If

        If chkGeographic2D.Checked Then
        Else
            If chkGeographic3D.Checked Then
            Else
                'Neither Geographic 2D or Geographic 3D checked.
                Main.Message.SetWarningStyle()
                Main.Message.Add("Neither Geographic 2D or Geographic 3D checked." & vbCrLf)
                Main.Message.SetNormalStyle()
                Exit Sub
            End If
        End If

        'Dim command As New XElement("Command", "GetGeographicCRSList")
        Dim command As New XElement("Command", "OK")
        operation.Add(command)

        xmessage.Add(operation)
        doc.Add(xmessage)

        'Send the instructions to the Coordinates application:
        If IsNothing(Main.client) Then
            Main.Message.Add("No client connection available!" & vbCrLf)
        Else
            If Main.client.State = ServiceModel.CommunicationState.Faulted Then
                Main.Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                Main.cmbGeoCRS.Items.Clear()
                'Main.client.SendMessageAsync("ADVL_Coordinates_1", doc.ToString)
                'Main.client.SendMessageAsync(Main.AppNetName, "ADVL_Coordinates_1", doc.ToString)
                Main.client.SendMessageAsync(Main.ProNetName, "ADVL_Coordinates_1", doc.ToString)
                'Main.Message.XAddText("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf, "XmlSentNotice")
                Main.Message.XAddText("Message sent to [" & Main.ProNetName & "]." & "ADVL_Coordinates_1" & ":" & vbCrLf, "XmlSentNotice")
                Main.Message.XAddXml(doc.ToString)
                Main.Message.XAddText(vbCrLf, "Normal") 'Add extra line
            End If
        End If

    End Sub

    Private Sub btnGetProjCRSList_Click(sender As Object, e As EventArgs) Handles btnGetProjCRSList.Click
        'Send instructions to the Coordinates application to get a list of Projected coordinate reference systems.

        'Create the xml instructions
        Dim decl As New XDeclaration("1.0", "utf-8", "yes")
        Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
        Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
        'Dim clientName As New XElement("ClientName", Main.ApplicationInfo.Name) 'This tells the coordinate server the name of the client making the request.
        'xmessage.Add(clientName)

        'ADDED 3Feb19:
        'Dim clientAppNetName As New XElement("ClientAppNetName", Main.AppNetName)
        'xmessage.Add(clientAppNetName)
        Dim clientProjectNetName As New XElement("ClientProNetName", Main.ProNetName)
        xmessage.Add(clientProjectNetName)

        Dim clientConnName As New XElement("ClientConnectionName", Main.ConnectionName) 'This tells the coordinate server the name of the client making the request.
        xmessage.Add(clientConnName)

        'Specifications for the Geographic CRS list.:
        'Dim operation As New XElement("GetProjectedCRSList")
        Dim operation As New XElement("GetProjectedCrsList")

        If rbGetAll.Checked Then 'Get all the Projected CRSs
            Dim SelectMethod As New XElement("SelectMethod", "All")
            operation.Add(SelectMethod)
        Else 'Get Projected CRSs within specified boundaries.
            Dim NorthLatitude As New XElement("NorthLatitude", NorthLat)
            operation.Add(NorthLatitude)
            Dim SouthLatitude As New XElement("SouthLatitude", SouthLat)
            operation.Add(SouthLatitude)
            Dim WestLongitude As New XElement("WestLongitude", WestLong)
            operation.Add(WestLongitude)
            Dim EastLongitude As New XElement("EastLongitude", EastLong)
            operation.Add(EastLongitude)
            If rbExtendingInto.Checked Then
                Dim SelectMethod As New XElement("SelectMethod", "ExtendingInto")
                operation.Add(SelectMethod)
            ElseIf rbInside.Checked Then
                Dim SelectMethod As New XElement("SelectMethod", "Inside")
                operation.Add(SelectMethod)
            Else
                'Error
                Main.Message.SetWarningStyle()
                Main.Message.Add("Projected CRS selection error. No selection criteria specified." & vbCrLf)
                Main.Message.SetNormalStyle()
                Exit Sub
            End If
        End If

        Dim command As New XElement("Command", "OK")
        operation.Add(command)

        xmessage.Add(operation)
        doc.Add(xmessage)

        'Send the instructions to the Coordinates application:
        If IsNothing(Main.client) Then
            Main.Message.Add("No client connection available!" & vbCrLf)
        Else
            If Main.client.State = ServiceModel.CommunicationState.Faulted Then
                Main.Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                Main.cmbProjCRS.Items.Clear()
                'Main.client.SendMessageAsync("ADVL_Coordinates_1", doc.ToString)
                'Main.client.SendMessageAsync(Main.AppNetName, "ADVL_Coordinates_1", doc.ToString)
                Main.client.SendMessageAsync(Main.ProNetName, "ADVL_Coordinates_1", doc.ToString)
                'Main.Message.XAddText("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf, "XmlSentNotice")
                Main.Message.XAddText("Message sent to [" & Main.ProNetName & "]." & "ADVL_Coordinates_1" & ":" & vbCrLf, "XmlSentNotice")

                Main.Message.XAddXml(doc.ToString)
                Main.Message.XAddText(vbCrLf, "Normal") 'Add extra line
            End If
        End If
    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Class AngleDMS

        Public Enum Sign
            Positive
            Negative
        End Enum

        Private _degMinSecSign As Sign = Sign.Positive
        Property DegMinSecSign As Sign
            Get
                Return _degMinSecSign
            End Get
            Set(value As Sign)
                _degMinSecSign = value
            End Set
        End Property

        Private _degrees As Integer
        Property Degrees As Integer
            Get
                Return _degrees
            End Get
            Set(value As Integer)
                _degrees = value
            End Set
        End Property

        Private _minutes As Integer
        Property Minutes As Integer
            Get
                Return _minutes
            End Get
            Set(value As Integer)
                _minutes = value
            End Set
        End Property

        Private _seconds As Decimal
        Property Seconds As Decimal
            Get
                Return _seconds
            End Get
            Set(value As Decimal)
                _seconds = value
            End Set
        End Property

    End Class


End Class

