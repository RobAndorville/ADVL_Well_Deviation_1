
'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
'
'Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at
'
'http://www.apache.org/licenses/LICENSE-2.0
'
'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
''WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'
'----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Imports System.ComponentModel
Imports System.Security.Permissions
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
<System.Runtime.InteropServices.ComVisibleAttribute(True)>
Public Class Main
    'The ADVL_Well_Deviation_1 application stores and manipulates well deviation data.

#Region " Coding Notes - Notes on the code used in this class." '------------------------------------------------------------------------------------------------------------------------------

    'ADD THE SYSTEM UTILITIES REFERENCE: ==========================================================================================
    'The following references are required by this software: 
    'Project \ Add Reference... \ ADVL_Utilities_Library_1.dll
    'The Utilities Library is used for Project Management, Archive file management, running XSequence files and running XMessage files.
    'If there are problems with a reference, try deleting it from the references list and adding it again.

    'ADD THE SERVICE REFERENCE: ===================================================================================================
    'A service reference to the Message Service must be added to the source code before this service can be used.
    'This is used to connect to the Application Network.

    'Adding the service reference to a project that includes the WcfMsgServiceLib project: -----------------------------------------
    'Project \ Add Service Reference
    'Press the Discover button.
    'Expand the items in the Services window and select IMsgService.
    'Press OK.
    '------------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------------------------
    'Adding the service reference to other projects that dont include the WcfMsgServiceLib project: -------------------------------
    'Run the ADVL_Application_Network_1 application to start the Application Network message service.
    'In Microsoft Visual Studio select: Project \ Add Service Reference
    'Enter the address: http://localhost:8734/ADVLService
    'Press the Go button.
    'MsgService is found.
    'Press OK to add ServiceReference1 to the project.
    '------------------------------------------------------------------------------------------------------------------------------
    '
    'ADD THE MsgServiceCallback CODE: =============================================================================================
    'This is used to connect to the Application Network.
    'In Microsoft Visual Studio select: Project \ Add Class
    'MsgServiceCallback.vb
    'Add the following code to the class:
    'Imports System.ServiceModel
    'Public Class MsgServiceCallback
    '    Implements ServiceReference1.IMsgServiceCallback
    '    Public Sub OnSendMessage(message As String) Implements ServiceReference1.IMsgServiceCallback.OnSendMessage
    '        'A message has been received.
    '        'Set the InstrReceived property value to the message (usually in XMessage format). This will also apply the instructions in the XMessage.
    '        Main.InstrReceived = message
    '    End Sub
    'End Class
    '------------------------------------------------------------------------------------------------------------------------------

#End Region 'Coding Notes ---------------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Variable Declarations - All the variables and class objects used in this form and this application." '-------------------------------------------------------------------------------------------------

    Public WithEvents ApplicationInfo As New ADVL_Utilities_Library_1.ApplicationInfo 'This object is used to store application information.
    Public WithEvents Project As New ADVL_Utilities_Library_1.Project 'This object is used to store Project information.
    Public WithEvents Message As New ADVL_Utilities_Library_1.Message 'This object is used to display messages in the Messages window.
    Public WithEvents ApplicationUsage As New ADVL_Utilities_Library_1.Usage 'This object stores application usage information.

    'Declare Forms used by the application:
    Public WithEvents GetCRSListForm As frmGetCRSList 'Form used to get a list of Geographic or Project coordinate reference systems.

    Public WithEvents WebPageList As frmWebPageList
    Public WithEvents ProjectArchive As frmArchive 'Form used to view the files in a Project archive
    Public WithEvents SettingsArchive As frmArchive 'Form used to view the files in a Settings archive
    Public WithEvents DataArchive As frmArchive 'Form used to view the files in a Data archive
    Public WithEvents SystemArchive As frmArchive 'Form used to view the files in a System archive

    Public WithEvents NewHtmlDisplay As frmHtmlDisplay
    Public HtmlDisplayFormList As New ArrayList 'Used for displaying multiple HtmlDisplay forms.

    Public WithEvents NewWebPage As frmWebPage
    Public WebPageFormList As New ArrayList 'Used for displaying multiple WebView forms.

    'Declare objects used to connect to the Message Service:
    Public client As ServiceReference1.MsgServiceClient
    Public WithEvents XMsg As New ADVL_Utilities_Library_1.XMessage
    Dim XDoc As New System.Xml.XmlDocument
    Public Status As New System.Collections.Specialized.StringCollection
    Dim ClientProNetName As String = "" 'The name of the client Project Network requesting service. 
    Dim ClientAppName As String = "" 'The name of the client requesting service
    Dim ClientConnName As String = "" 'The name of the client connection requesting service
    Dim MessageXDoc As System.Xml.Linq.XDocument
    Dim xmessage As XElement 'This will contain the message. It will be added to MessageXDoc.
    Dim xlocns As New List(Of XElement) 'A list of locations. Each location forms part of the reply message. The information in the reply message will be sent to the specified location in the client application.
    Dim MessageText As String = "" 'The text of a message sent through the Application Network

    'Dim CompletionInstruction As String = "Stop" 'The last instruction returned on completion of the processing of an XMessage.
    Public OnCompletionInstruction As String = "Stop" 'The last instruction returned in <EndInstruction> on completion of the processing of an XMessage.
    Public EndInstruction As String = "Stop" 'Another method of specifying the last instruction. This is processed in the EndOfSequence section of XMsg.Instructions.

    Public ConnectionName As String = "" 'The name of the connection used to connect this application to the AppNet.

    Public ProNetName As String = "" 'The name of the Project Network
    Public ProNetPath As String = "" 'The path of the Project Network

    Public AdvlNetworkAppPath As String = "" 'The application path of the ADVL Network application (ComNet). This is where the "Application.Lock" file will be while ComNet is running
    Public AdvlNetworkExePath As String = "" 'The executable path of the ADVL Network.

    'Variable for local processing of an XMessage:
    Public WithEvents XMsgLocal As New ADVL_Utilities_Library_1.XMessage
    Dim XDocLocal As New System.Xml.XmlDocument
    Public StatusLocal As New System.Collections.Specialized.StringCollection

    Public dictDistanceUnits As New Dictionary(Of String, ConversionFactors) 'Dictionary of distance units.
    Public dictAngleUnits As New Dictionary(Of String, ConversionFactors) 'Dictionary of angle units.

    Dim Angle As New clsAngle 'Used to convert between decimal degrees and deg min sec.

    Dim WithEvents Zip As ADVL_Utilities_Library_1.ZipComp

    'Main.Load variables:
    Dim ProjectSelected As Boolean = False 'If True, a project has been selected using Command Arguments. Used in Main.Load.
    Dim StartupConnectionName As String = "" 'If not "" the application will be connected to the AppNet using this connection name in  Main.Load.

    'The following variables are used to run JavaScript in Web Pages loaded into the Document View: -------------------
    Public WithEvents XSeq As New ADVL_Utilities_Library_1.XSequence
    'To run an XSequence:
    '  XSeq.RunXSequence(xDoc, Status) 'ImportStatus in Import
    '    Handle events:
    '      XSeq.ErrorMsg
    '      XSeq.Instruction(Info, Locn)

    Private XStatus As New System.Collections.Specialized.StringCollection

    'Variables used to restore Item values on a web page.
    Private FormName As String
    Private ItemName As String
    Private SelectId As String

    'StartProject variables:
    Private StartProject_AppName As String  'The application name
    Private StartProject_ConnName As String 'The connection name
    Private StartProject_ProjID As String   'The project ID

    Private WithEvents bgwComCheck As New System.ComponentModel.BackgroundWorker 'Used to perform communication checks on a separate thread.

    Public WithEvents bgwSendMessage As New System.ComponentModel.BackgroundWorker 'Used to send a message through the Message Service.
    Dim SendMessageParams As New clsSendMessageParams 'This hold the Send Message parameters: .ProjectNetworkName, .ConnectionName & .Message

    'Alternative SendMessage background worker - needed to send a message while instructions are being processed.
    Public WithEvents bgwSendMessageAlt As New System.ComponentModel.BackgroundWorker 'Used to send a message through the Message Service - alternative backgound worker.
    Dim SendMessageParamsAlt As New clsSendMessageParams 'This hold the Send Message parameters: .ProjectNetworkName, .ConnectionName & .Message - for the alternative background worker.

#End Region 'Variable Declarations ------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Properties - All the properties used in this form and this application" '------------------------------------------------------------------------------------------------------------

    Private _connectionHashcode As Integer 'The Application Network connection hashcode. This is used to identify a connection in the Application Netowrk when reconnecting.
    Property ConnectionHashcode As Integer
        Get
            Return _connectionHashcode
        End Get
        Set(value As Integer)
            _connectionHashcode = value
        End Set
    End Property

    Private _connectedToComNet As Boolean = False  'True if the application is connected to the Communication Network.
    Property ConnectedToComNet As Boolean
        Get
            Return _connectedToComNet
        End Get
        Set(value As Boolean)
            _connectedToComNet = value
        End Set
    End Property

    Private _instrReceived As String = "" 'Contains Instructions received from the Application Network message service.
    Property InstrReceived As String
        Get
            Return _instrReceived
        End Get
        Set(value As String)
            If value = Nothing Then
                Message.Add("Empty message received!")
            Else
                _instrReceived = value
                ProcessInstructions(_instrReceived)
            End If
        End Set
    End Property

    Private Sub ProcessInstructions(ByVal Instructions As String)
        'Process the XMessage instructions.

        Dim MsgType As String
        If Instructions.StartsWith("<XMsg>") Then
            MsgType = "XMsg"
            If ShowXMessages Then
                'Add the message header to the XMessages window:
                Message.XAddText("Message received: " & vbCrLf, "XmlReceivedNotice")
            End If
        ElseIf Instructions.StartsWith("<XSys>") Then
            MsgType = "XSys"
            If ShowSysMessages Then
                'Add the message header to the XMessages window:
                Message.XAddText("System Message received: " & vbCrLf, "XmlReceivedNotice")
            End If
        Else
            MsgType = "Unknown"
        End If

        'If ShowXMessages Then
        '    'Add the message header to the XMessages window:
        '    Message.XAddText("Message received: " & vbCrLf, "XmlReceivedNotice")
        'End If

        'If Instructions.StartsWith("<XMsg>") Then 'This is an XMessage set of instructions.
        If MsgType = "XMsg" Or MsgType = "XSys" Then 'This is an XMessage or XSystem set of instructions.
                Try
                    'Inititalise the reply message:
                    ClientProNetName = ""
                    ClientConnName = ""
                    ClientAppName = ""
                    xlocns.Clear() 'Clear the list of locations in the reply message. ADDED 22Jul19
                    Dim Decl As New XDeclaration("1.0", "utf-8", "yes")
                    MessageXDoc = New XDocument(Decl, Nothing) 'Reply message - this will be sent to the Client App.
                'xmessage = New XElement("XMsg")
                xmessage = New XElement(MsgType)
                xlocns.Add(New XElement("Main")) 'Initially set the location in the Client App to Main.

                    'Run the received message:
                    Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                    XDoc.LoadXml(XmlHeader & vbCrLf & Instructions.Replace("&", "&amp;")) 'Replace "&" with "&amp:" before loading the XML text.
                'If ShowXMessages Then
                '    Message.XAddXml(XDoc)   'Add the message to the XMessages window.
                '    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                'End If
                If (MsgType = "XMsg") And ShowXMessages Then
                    Message.XAddXml(XDoc)  'Add the message to the XMessages window.
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                ElseIf (MsgType = "XSys") And ShowSysMessages Then
                    Message.XAddXml(XDoc)  'Add the message to the XMessages window.
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If
                XMsg.Run(XDoc, Status)
                Catch ex As Exception
                    Message.Add("Error running XMsg: " & ex.Message & vbCrLf)
                End Try

                'XMessage has been run.
                'Reply to this message:
                'Add the message reply to the XMessages window:
                'Complete the MessageXDoc:
                xmessage.Add(xlocns(xlocns.Count - 1)) 'Add the last location reply instructions to the message.
                MessageXDoc.Add(xmessage)
                MessageText = MessageXDoc.ToString

                If ClientConnName = "" Then
                'No client to send a message to - process the message locally.
                'If ShowXMessages Then
                '    Message.XAddText("Message processed locally:" & vbCrLf, "XmlSentNotice")
                '    Message.XAddXml(MessageText)
                '    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                'End If
                If (MsgType = "XMsg") And ShowXMessages Then
                    Message.XAddText("Message processed locally:" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                ElseIf (MsgType = "XSys") And ShowSysMessages Then
                    Message.XAddText("System Message processed locally:" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If
                ProcessLocalInstructions(MessageText)
                Else
                'If ShowXMessages Then
                '    Message.XAddText("Message sent to [" & ClientProNetName & "]." & ClientConnName & ":" & vbCrLf, "XmlSentNotice")
                '    Message.XAddXml(MessageText)
                '    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                'End If
                If (MsgType = "XMsg") And ShowXMessages Then
                    Message.XAddText("Message sent to [" & ClientProNetName & "]." & ClientConnName & ":" & vbCrLf, "XmlSentNotice")   'NOTE: There is no SendMessage code in the Message Service application!
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                ElseIf (MsgType = "XSys") And ShowSysMessages Then
                    Message.XAddText("System Message sent to [" & ClientProNetName & "]." & ClientConnName & ":" & vbCrLf, "XmlSentNotice")   'NOTE: There is no SendMessage code in the Message Service application!
                    Message.XAddXml(MessageText)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If

                'Send Message on a new thread:
                SendMessageParams.ProjectNetworkName = ClientProNetName
                    SendMessageParams.ConnectionName = ClientConnName
                    SendMessageParams.Message = MessageText
                    If bgwSendMessage.IsBusy Then
                        Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                    Else
                        bgwSendMessage.RunWorkerAsync(SendMessageParams)
                    End If
                End If
            Else 'This is not an XMessage!
                If Instructions.StartsWith("<XMsgBlk>") Then 'This is an XMessageBlock.
                'Process the received message:
                Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                XDoc.LoadXml(XmlHeader & vbCrLf & Instructions.Replace("&", "&amp;")) 'Replace "&" with "&amp:" before loading the XML text.
                If ShowXMessages Then
                    Message.XAddXml(XDoc)   'Add the message to the XMessages window.
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                End If

                'Process the XMessageBlock:
                Dim XMsgBlkLocn As String
                XMsgBlkLocn = XDoc.GetElementsByTagName("ClientLocn")(0).InnerText
                Select Case XMsgBlkLocn
                    Case "TestLocn" 'Replace this with the required location name.
                        Dim XInfo As Xml.XmlNodeList = XDoc.GetElementsByTagName("XInfo") 'Get the XInfo node list
                        Dim InfoXDoc As New Xml.Linq.XDocument 'Create an XDocument to hold the information contained in XInfo 
                        InfoXDoc = XDocument.Parse("<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>" & vbCrLf & XInfo(0).InnerXml) 'Read the information into InfoXDoc
                        'Add processing instructions here - The information in the InfoXDoc is usually stored in an XDocument in the application or as an XML file in the project.

                    Case Else
                        Message.AddWarning("Unknown XInfo Message location: " & XMsgBlkLocn & vbCrLf)
                End Select
            Else
                Message.XAddText("The message is not an XMessage or XMessageBlock: " & vbCrLf & Instructions & vbCrLf & vbCrLf, "Normal")
            End If
            'Message.XAddText("The message is not an XMessage: " & Instructions & vbCrLf, "Normal")
        End If
    End Sub

    Private Sub ProcessLocalInstructions(ByVal Instructions As String)
        'Process the XMessage instructions locally.

        'If Instructions.StartsWith("<XMsg>") Then 'This is an XMessage set of instructions.
        If Instructions.StartsWith("<XMsg>") Or Instructions.StartsWith("<XSys>") Then 'This is an XMessage set of instructions.
                'Run the received message:
                Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
                XDocLocal.LoadXml(XmlHeader & vbCrLf & Instructions)
                XMsgLocal.Run(XDocLocal, StatusLocal)
            Else 'This is not an XMessage!
                Message.XAddText("The message is not an XMessage: " & Instructions & vbCrLf, "Normal")
        End If
    End Sub

    Private _showXMessages As Boolean = True 'If True, XMessages that are sent or received will be shown in the Messages window.
    Property ShowXMessages As Boolean
        Get
            Return _showXMessages
        End Get
        Set(value As Boolean)
            _showXMessages = value
        End Set
    End Property

    Private _showSysMessages As Boolean = True 'If True, System messages that are sent or received will be shown in the messages window.
    Property ShowSysMessages As Boolean
        Get
            Return _showSysMessages
        End Get
        Set(value As Boolean)
            _showSysMessages = value
        End Set
    End Property

    Public Enum DepthUnits
        metre
        foot
    End Enum

    Private _depthUnit As DepthUnits 'The depth units of the deviation survey depth measurement.
    Property DepthUnit As DepthUnits
        Get
            Return _depthUnit
        End Get
        Set(value As DepthUnits)
            _depthUnit = value
            If _depthUnit = DepthUnits.foot Then
                dgvMeasuredData.Columns(0).HeaderText = "Measured Depth" & vbCrLf & "(Feet RT)"
            Else
                dgvMeasuredData.Columns(0).HeaderText = "Measured Depth" & vbCrLf & "(" & _depthUnit.ToString & "s RT)"
            End If

        End Set
    End Property

    Public Enum AngleUnits
        radian
        degree
    End Enum

    Private _angleUnit As AngleUnits
    Property AngleUnit As AngleUnits
        Get
            Return _angleUnit
        End Get
        Set(value As AngleUnits)
            _angleUnit = value
            dgvMeasuredData.Columns(1).HeaderText = "Inclination" & vbCrLf & "(" & _angleUnit.ToString & "s)"
            dgvMeasuredData.Columns(2).HeaderText = "Azimuth" & vbCrLf & "(" & _angleUnit.ToString & "s)" & vbCrLf & "(" & _northReference.ToString & ")"
        End Set
    End Property

    'Public Enum WellPathCalcMethods
    '    AverageAngle
    '    BalancedAngle
    '    MinimumCurvature
    '    RadiusOfCurvature
    '    Tangential
    'End Enum

    'Private _wellPathCalcMethod As WellPathCalcMethods 'The method to calculate the well path from the deviation log data.
    'Property WellPathCalcMethod As WellPathCalcMethods
    '    Get
    '        Return _wellPathCalcMethod
    '    End Get
    '    Set(value As WellPathCalcMethods)
    '        _wellPathCalcMethod = value
    '    End Set
    'End Property

    Private _fileName As String = "" 'The name of the file used to store the current well deviation data.
    Property FileName As String
        Get
            Return _fileName
        End Get
        Set(value As String)
            _fileName = value
            txtFileName.Text = _fileName
        End Set
    End Property


    Private _wellName As String 'The name of the selected well.
    Property WellName As String
        Get
            Return _wellName
        End Get
        Set(value As String)
            _wellName = value
            txtWellName.Text = _wellName
        End Set
    End Property

    Private _borehole As String 'The name of the selected borehole in the selected well.
    Property Borehole As String
        Get
            Return _borehole
        End Get
        Set(value As String)
            _borehole = value
            txtBoreholeName.Text = _borehole
        End Set
    End Property

    'The following parameters are stored as text in on the Well Information tab:
    'Rotary Table height.
    'The latitude of the well surface location (decimal degrees)
    'The longitude of the well surface location (decimal degrees)
    'The Easting of the well surface location
    'The Northing of the well surface location

    Public Enum NorthReferences
        MagneticNorth
        TrueNorth
        GridNorth
    End Enum
    Private _northReference As NorthReferences 'The reference used to define the azimuth angle.
    Property NorthReference As NorthReferences
        Get
            Return _northReference
        End Get
        Set(value As NorthReferences)
            _northReference = value
            dgvMeasuredData.Columns(2).HeaderText = "Azimuth" & vbCrLf & "(" & _angleUnit.ToString & "s)" & vbCrLf & "(" & _northReference.ToString & ")"
        End Set
    End Property

    Private _calcDepthUnit As DepthUnits
    Property CalcDepthUnit As DepthUnits
        Get
            Return _calcDepthUnit
        End Get
        Set(value As DepthUnits)
            _calcDepthUnit = value
            If _calcDepthUnit = DepthUnits.foot Then
                dgvCalculatedData.Columns(0).HeaderText = "True Vertical Depth" & vbCrLf & "(Feet RT)"
            Else
                dgvCalculatedData.Columns(0).HeaderText = "True Vertical Depth" & vbCrLf & "(" & _calcDepthUnit.ToString & "s RT)"
            End If

        End Set
    End Property

    Public Enum DistanceUnits
        metre
        foot
    End Enum

    Private _calcOffsetUnit As DistanceUnits
    Property CalcOffsetUnit As DistanceUnits
        Get
            Return _calcOffsetUnit
        End Get
        Set(value As DistanceUnits)
            _calcOffsetUnit = value
            If _calcOffsetUnit = DistanceUnits.foot Then
                dgvCalculatedData.Columns(1).HeaderText = "dX" & vbCrLf & "(Feet)"
                dgvCalculatedData.Columns(2).HeaderText = "dY" & vbCrLf & "(Feet)"
            Else
                dgvCalculatedData.Columns(1).HeaderText = "dX" & vbCrLf & "(" & _calcOffsetUnit.ToString & "s)"
                dgvCalculatedData.Columns(2).HeaderText = "dY" & vbCrLf & "(" & _calcOffsetUnit.ToString & "s)"
            End If

        End Set
    End Property


    'INTERPOLATION TYPE SETTING IS STORED IN THE cmbCalcMethod combo box - No need for a separate property.
    'Enum InterpolationTypes
    '    Linear
    '    CubicSpline
    'End Enum

    'Private _interpolationType As InterpolationTypes
    'Property InterpolationType As InterpolationTypes
    '    Get
    '        Return _interpolationType
    '    End Get
    '    Set(value As InterpolationTypes)
    '        _interpolationType = value
    'End Set
    'End Property

    'INTERPOLATION INPUT DEPTH TYPE SETTING IS STORED IN THE cmbInputDepth combo box - No need for a separate property.
    'Enum InputDepthTypes
    '    MeasuredDepthRT
    '    MeasuredDepthSubsea
    'End Enum
    'Private _interpolationInputDepthType As InputDepthTypes
    'Property InterpolationInputDepthType As InputDepthTypes
    '    Get
    '        Return _interpolationInputDepthType
    '    End Get
    '    Set(value As InputDepthTypes)
    '        _interpolationInputDepthType = value
    '    End Set
    'End Property

    Private _closedFormNo As Integer 'Temporarily holds the number of the form that is being closed. 
    Property ClosedFormNo As Integer
        Get
            Return _closedFormNo
        End Get
        Set(value As Integer)
            _closedFormNo = value
        End Set
    End Property

    'Private _startPageFileName As String = "" 'The file name of the html document displayed in the Start Page tab.
    'Public Property StartPageFileName As String
    '    Get
    '        Return _startPageFileName
    '    End Get
    '    Set(value As String)
    '        _startPageFileName = value
    '    End Set
    'End Property

    Private _workflowFileName As String = "" 'The file name of the html document displayed in the Workflow tab.
    Public Property WorkflowFileName As String
        Get
            Return _workflowFileName
        End Get
        Set(value As String)
            _workflowFileName = value
        End Set
    End Property

#End Region 'Properties -----------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Process XML files - Read and write XML files." '-------------------------------------------------------------------------------------------------------------------------------------

    Private Sub SaveFormSettings()
        'Save the form settings in an XML document.

        'Apply default settings if required:
        'If cmbGeoCRS.SelectedItem Is Nothing Then
        If IsNothing(cmbGeoCRS.SelectedItem) Then
            If cmbGeoCRS.Items.Count = 0 Then
                cmbGeoCRS.Items.Add("None")
            End If
            'cmbGeoCRS.SelectedItem = 0
            cmbGeoCRS.SelectedIndex = 0
        End If
        'If cmbProjCRS.SelectedItem Is Nothing Then
        If IsNothing(cmbProjCRS.SelectedItem) Then
            If cmbProjCRS.Items.Count = 0 Then
                cmbProjCRS.Items.Add("None")
            End If
            'cmbProjCRS.SelectedItem = 0
            cmbProjCRS.SelectedIndex = 0
        End If

        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <!--Form settings for Main form.-->
                           <FormSettings>
                               <Left><%= Me.Left %></Left>
                               <Top><%= Me.Top %></Top>
                               <Width><%= Me.Width %></Width>
                               <Height><%= Me.Height %></Height>
                               <AdvlNetworkAppPath><%= AdvlNetworkAppPath %></AdvlNetworkAppPath>
                               <AdvlNetworkExePath><%= AdvlNetworkExePath %></AdvlNetworkExePath>
                               <ShowXMessages><%= ShowXMessages %></ShowXMessages>
                               <ShowSysMessages><%= ShowSysMessages %></ShowSysMessages>
                               <WorkFlowFileName><%= WorkflowFileName %></WorkFlowFileName>
                               <!---->
                               <SelectedTabIndex><%= TabControl1.SelectedIndex %></SelectedTabIndex>
                               <!---->
                               <GeographicCrsList>
                                   <%= From item In cmbGeoCRS.Items
                                       Select
                                       <GeographicCrsName><%= item %></GeographicCrsName>
                                   %>
                               </GeographicCrsList>
                               <!---->
                               <SelectedGeographicCrs><%= cmbGeoCRS.SelectedItem.ToString %></SelectedGeographicCrs>
                               <!---->
                               <ProjectedCrsList>
                                   <%= From item In cmbProjCRS.Items
                                       Select
                                       <ProjectedCrsName><%= item %></ProjectedCrsName>
                                   %>
                               </ProjectedCrsList>
                               <!---->
                               <SelectedProjectedCrs><%= cmbProjCRS.SelectedItem.ToString %></SelectedProjectedCrs>
                               <!---->
                               <WellFileName><%= FileName %></WellFileName>
                               <!---->
                               <WellPathCalculationMethod><%= cmbCalcMethod.SelectedItem.ToString %></WellPathCalculationMethod>
                               <InterpolationType><%= cmbInterpolationType.SelectedItem.ToString %></InterpolationType>
                               <InputDepthType><%= cmbInputDepth.SelectedItem.ToString %></InputDepthType>
                           </FormSettings>

        'Add code to include other settings to save after the comment line <!---->

        'Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & " - Main.xml"
        Project.SaveXmlSettings(SettingsFileName, settingsData)
    End Sub

    Private Sub RestoreFormSettings()
        'Read the form settings from an XML document.

        'Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Dim SettingsFileName As String = "FormSettings_" & ApplicationInfo.Name & " - Main.xml"

        If Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Project.ReadXmlSettings(SettingsFileName, Settings)

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

            If Settings.<FormSettings>.<AdvlNetworkAppPath>.Value <> Nothing Then AdvlNetworkAppPath = Settings.<FormSettings>.<AdvlNetworkAppPath>.Value
            If Settings.<FormSettings>.<AdvlNetworkExePath>.Value <> Nothing Then AdvlNetworkExePath = Settings.<FormSettings>.<AdvlNetworkExePath>.Value

            If Settings.<FormSettings>.<ShowXMessages>.Value <> Nothing Then ShowXMessages = Settings.<FormSettings>.<ShowXMessages>.Value
            If Settings.<FormSettings>.<ShowSysMessages>.Value <> Nothing Then ShowSysMessages = Settings.<FormSettings>.<ShowSysMessages>.Value

            If Settings.<FormSettings>.<WorkFlowFileName>.Value <> Nothing Then WorkflowFileName = Settings.<FormSettings>.<WorkFlowFileName>.Value

            'Add code to read other saved setting here:
            If Settings.<FormSettings>.<SelectedTabIndex>.Value <> Nothing Then TabControl1.SelectedIndex = Settings.<FormSettings>.<SelectedTabIndex>.Value

            For Each Item In Settings.<FormSettings>.<GeographicCrsList>.<GeographicCrsName>
                cmbGeoCRS.Items.Add(Item.Value)
            Next

            If Settings.<FormSettings>.<SelectedGeographicCrs>.Value <> Nothing Then cmbGeoCRS.SelectedIndex = cmbGeoCRS.FindStringExact(Settings.<FormSettings>.<SelectedGeographicCrs>.Value)

            For Each Item In Settings.<FormSettings>.<ProjectedCrsList>.<ProjectedCrsName>
                cmbProjCRS.Items.Add(Item.Value)
            Next

            If Settings.<FormSettings>.<SelectedProjectedCrs>.Value <> Nothing Then cmbProjCRS.SelectedIndex = cmbProjCRS.FindStringExact(Settings.<FormSettings>.<SelectedProjectedCrs>.Value)

            If Settings.<FormSettings>.<WellFileName>.Value = Nothing Then
                FileName = ""
            Else
                FileName = Settings.<FormSettings>.<WellFileName>.Value
            End If

            If Settings.<FormSettings>.<WellPathCalculationMethod>.Value <> Nothing Then cmbCalcMethod.SelectedIndex = cmbCalcMethod.FindStringExact(Settings.<FormSettings>.<WellPathCalculationMethod>.Value)
            If Settings.<FormSettings>.<InterpolationType>.Value <> Nothing Then cmbInterpolationType.SelectedIndex = cmbInterpolationType.FindStringExact(Settings.<FormSettings>.<InterpolationType>.Value)
            If Settings.<FormSettings>.<InputDepthType>.Value <> Nothing Then cmbInputDepth.SelectedIndex = cmbInputDepth.FindStringExact(Settings.<FormSettings>.<InputDepthType>.Value)
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

    Private Sub ReadApplicationInfo()
        'Read the Application Information.

        If ApplicationInfo.FileExists Then
            ApplicationInfo.ReadFile()
        Else
            'There is no Application_Info_ADVL_2.xml file.
            DefaultAppProperties() 'Create a new Application Info file with default application properties:
            ApplicationInfo.WriteFile() 'Write the file now. The file information may be used by other applications.
        End If
    End Sub

    Private Sub DefaultAppProperties()
        'These properties will be saved in the Application_Info.xml file in the application directory.
        'If this file is deleted, it will be re-created using these default application properties.

        'Change this to show your application Name, Description and Creation Date.
        ApplicationInfo.Name = "ADVL_Well_Deviation_1"

        'ApplicationInfo.ApplicationDir is set when the application is started.
        ApplicationInfo.ExecutablePath = Application.ExecutablePath

        ApplicationInfo.Description = "Storage and manipulation of well deviation data."
        ApplicationInfo.CreationDate = "22-Aug-2016 12:00:00"

        'Author -----------------------------------------------------------------------------------------------------------
        'Change this to show your Name, Description and Contact information.
        ApplicationInfo.Author.Name = "Signalworks Pty Ltd"
        ApplicationInfo.Author.Description = "Signalworks Pty Ltd" & vbCrLf &
            "Australian Proprietary Company" & vbCrLf &
            "ABN 26 066 681 598" & vbCrLf &
            "Registration Date 05/10/1994"

        ApplicationInfo.Author.Contact = "http://www.andorville.com.au/"

        'File Associations: -----------------------------------------------------------------------------------------------
        'Add any file associations here.
        'The file extension and a description of files that can be opened by this application are specified.
        'The example below specifies a coordinate system parameter file type with the file extension .ADVLCoord.
        'Dim Assn1 As New ADVL_System_Utilities.FileAssociation
        'Assn1.Extension = "ADVLCoord"
        'Assn1.Description = "Andorville (TM) software coordinate system parameter file"
        'ApplicationInfo.FileAssociations.Add(Assn1)

        'Version ----------------------------------------------------------------------------------------------------------
        ApplicationInfo.Version.Major = My.Application.Info.Version.Major
        ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
        ApplicationInfo.Version.Build = My.Application.Info.Version.Build
        ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision

        'Copyright --------------------------------------------------------------------------------------------------------
        'Add your copyright information here.
        ApplicationInfo.Copyright.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        ApplicationInfo.Copyright.PublicationYear = "2016"

        'Trademarks -------------------------------------------------------------------------------------------------------
        'Add your trademark information here.
        Dim Trademark1 As New ADVL_Utilities_Library_1.Trademark
        Trademark1.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        Trademark1.Text = "Andorville"
        Trademark1.Registered = False
        Trademark1.GenericTerm = "software"
        ApplicationInfo.Trademarks.Add(Trademark1)
        Dim Trademark2 As New ADVL_Utilities_Library_1.Trademark
        Trademark2.OwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        Trademark2.Text = "AL-H7"
        Trademark2.Registered = False
        Trademark2.GenericTerm = "software"
        ApplicationInfo.Trademarks.Add(Trademark2)

        'License -------------------------------------------------------------------------------------------------------
        'Add your license information here.
        ApplicationInfo.License.CopyrightOwnerName = "Signalworks Pty Ltd, ABN 26 066 681 598"
        ApplicationInfo.License.PublicationYear = "2016"

        'License Links:
        'http://choosealicense.com/
        'http://www.apache.org/licenses/
        'http://opensource.org/

        'Apache License 2.0 ---------------------------------------------
        ApplicationInfo.License.Code = ADVL_Utilities_Library_1.License.Codes.Apache_License_2_0
        ApplicationInfo.License.Notice = ApplicationInfo.License.ApacheLicenseNotice 'Get the pre-defined Aapche license notice.
        ApplicationInfo.License.Text = ApplicationInfo.License.ApacheLicenseText     'Get the pre-defined Apache license text.

        'Code to use other pre-defined license types is shown below:

        'GNU General Public License, version 3 --------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.GNU_GPL_V3_0
        'ApplicationInfo.License.Notice = 'Add the License Notice to ADVL_Utilities_Library_1 License class.
        'ApplicationInfo.License.Text = 'Add the License Text to ADVL_Utilities_Library_1 License class.

        'The MIT License ------------------------------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.MIT_License
        'ApplicationInfo.License.Notice = ApplicationInfo.License.MITLicenseNotice
        'ApplicationInfo.License.Text = ApplicationInfo.License.MITLicenseText

        'No License Specified -------------------------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.None
        'ApplicationInfo.License.Notice = ""
        'ApplicationInfo.License.Text = ""

        'The Unlicense --------------------------------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.The_Unlicense
        'ApplicationInfo.License.Notice = ApplicationInfo.License.UnLicenseNotice
        'ApplicationInfo.License.Text = ApplicationInfo.License.UnLicenseText

        'Unknown License ------------------------------------------------
        'ApplicationInfo.License.Type = ADVL_Utilities_Library_1.License.Types.Unknown
        'ApplicationInfo.License.Notice = ""
        'ApplicationInfo.License.Text = ""

        'Source Code: --------------------------------------------------------------------------------------------------
        'Add your source code information here if required.
        'THIS SECTION WILL BE UPDATED TO ALLOW A GITHUB LINK.
        ApplicationInfo.SourceCode.Language = "Visual Basic 2015"
        ApplicationInfo.SourceCode.FileName = ""
        ApplicationInfo.SourceCode.FileSize = 0
        ApplicationInfo.SourceCode.FileHash = ""
        ApplicationInfo.SourceCode.WebLink = ""
        ApplicationInfo.SourceCode.Contact = ""
        ApplicationInfo.SourceCode.Comments = ""

        'ModificationSummary: -----------------------------------------------------------------------------------------
        'Add any source code modification here is required.
        ApplicationInfo.ModificationSummary.BaseCodeName = ""
        ApplicationInfo.ModificationSummary.BaseCodeDescription = ""
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Major = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Minor = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Build = 0
        ApplicationInfo.ModificationSummary.BaseCodeVersion.Revision = 0
        ApplicationInfo.ModificationSummary.Description = "This is the first released version of the application. No earlier base code used."

        'Library List: ------------------------------------------------------------------------------------------------
        'Add the ADVL_Utilties_Library_1 library:
        Dim NewLib As New ADVL_Utilities_Library_1.LibrarySummary
        NewLib.Name = "ADVL_System_Utilities"
        NewLib.Description = "System Utility classes used in Andorville (TM) software development system applications"
        NewLib.CreationDate = "7-Jan-2016 12:00:00"
        NewLib.LicenseNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598" & vbCrLf &
                               vbCrLf &
                               "Licensed under the Apache License, Version 2.0 (the ""License"");" & vbCrLf &
                               "you may not use this file except in compliance with the License." & vbCrLf &
                               "You may obtain a copy of the License at" & vbCrLf &
                               vbCrLf &
                               "http://www.apache.org/licenses/LICENSE-2.0" & vbCrLf &
                               vbCrLf &
                               "Unless required by applicable law or agreed to in writing, software" & vbCrLf &
                               "distributed under the License is distributed on an ""AS IS"" BASIS," & vbCrLf &
                               "WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied." & vbCrLf &
                               "See the License for the specific language governing permissions and" & vbCrLf &
                               "limitations under the License." & vbCrLf

        NewLib.CopyrightNotice = "Copyright 2016 Signalworks Pty Ltd, ABN 26 066 681 598"

        NewLib.Version.Major = 1
        NewLib.Version.Minor = 0
        NewLib.Version.Build = 1
        NewLib.Version.Revision = 0

        NewLib.Author.Name = "Signalworks Pty Ltd"
        NewLib.Author.Description = "Signalworks Pty Ltd" & vbCrLf &
            "Australian Proprietary Company" & vbCrLf &
            "ABN 26 066 681 598" & vbCrLf &
            "Registration Date 05/10/1994"

        NewLib.Author.Contact = "http://www.andorville.com.au/"

        Dim NewClass1 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass1.Name = "ZipComp"
        NewClass1.Description = "The ZipComp class is used to compress files into and extract files from a zip file."
        NewLib.Classes.Add(NewClass1)
        Dim NewClass2 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass2.Name = "XSequence"
        NewClass2.Description = "The XSequence class is used to run an XML property sequence (XSequence) file. XSequence files are used to record and replay processing sequences in Andorville (TM) software applications."
        NewLib.Classes.Add(NewClass2)
        Dim NewClass3 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass3.Name = "XMessage"
        NewClass3.Description = "The XMessage class is used to read an XML Message (XMessage). An XMessage is a simplified XSequence used to exchange information between Andorville (TM) software applications."
        NewLib.Classes.Add(NewClass3)
        Dim NewClass4 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass4.Name = "Location"
        NewClass4.Description = "The Location class consists of properties and methods to store data in a location, which is either a directory or archive file."
        NewLib.Classes.Add(NewClass4)
        Dim NewClass5 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass5.Name = "Project"
        NewClass5.Description = "An Andorville (TM) software application can store data within one or more projects. Each project stores a set of related data files. The Project class contains properties and methods used to manage a project."
        NewLib.Classes.Add(NewClass5)
        Dim NewClass6 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass6.Name = "ProjectSummary"
        NewClass6.Description = "ProjectSummary stores a summary of a project."
        NewLib.Classes.Add(NewClass6)
        Dim NewClass7 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass7.Name = "DataFileInfo"
        NewClass7.Description = "The DataFileInfo class stores information about a data file."
        NewLib.Classes.Add(NewClass7)
        Dim NewClass8 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass8.Name = "Message"
        NewClass8.Description = "The Message class contains text properties and methods used to display messages in an Andorville (TM) software application."
        NewLib.Classes.Add(NewClass8)
        Dim NewClass9 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass9.Name = "ApplicationSummary"
        NewClass9.Description = "The ApplicationSummary class stores a summary of an Andorville (TM) software application."
        NewLib.Classes.Add(NewClass9)
        Dim NewClass10 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass10.Name = "LibrarySummary"
        NewClass10.Description = "The LibrarySummary class stores a summary of a software library used by an application."
        NewLib.Classes.Add(NewClass10)
        Dim NewClass11 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass11.Name = "ClassSummary"
        NewClass11.Description = "The ClassSummary class stores a summary of a class contained in a software library."
        NewLib.Classes.Add(NewClass11)
        Dim NewClass12 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass12.Name = "ModificationSummary"
        NewClass12.Description = "The ModificationSummary class stores a summary of any modifications made to an application or library."
        NewLib.Classes.Add(NewClass12)
        Dim NewClass13 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass13.Name = "ApplicationInfo"
        NewClass13.Description = "The ApplicationInfo class stores information about an Andorville (TM) software application."
        NewLib.Classes.Add(NewClass13)
        Dim NewClass14 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass14.Name = "Version"
        NewClass14.Description = "The Version class stores application, library or project version information."
        NewLib.Classes.Add(NewClass14)
        Dim NewClass15 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass15.Name = "Author"
        NewClass15.Description = "The Author class stores information about an Author."
        NewLib.Classes.Add(NewClass15)
        Dim NewClass16 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass16.Name = "FileAssociation"
        NewClass16.Description = "The FileAssociation class stores the file association extension and description. An application can open files on its file association list."
        NewLib.Classes.Add(NewClass16)
        Dim NewClass17 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass17.Name = "Copyright"
        NewClass17.Description = "The Copyright class stores copyright information."
        NewLib.Classes.Add(NewClass17)
        Dim NewClass18 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass18.Name = "License"
        NewClass18.Description = "The License class stores license information."
        NewLib.Classes.Add(NewClass18)
        Dim NewClass19 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass19.Name = "SourceCode"
        NewClass19.Description = "The SourceCode class stores information about the source code for the application."
        NewLib.Classes.Add(NewClass19)
        Dim NewClass20 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass20.Name = "Usage"
        NewClass20.Description = "The Usage class stores information about application or project usage."
        NewLib.Classes.Add(NewClass20)
        Dim NewClass21 As New ADVL_Utilities_Library_1.ClassSummary
        NewClass21.Name = "Trademark"
        NewClass21.Description = "The Trademark class stored information about a trademark used by the author of an application or data."
        NewLib.Classes.Add(NewClass21)

        ApplicationInfo.Libraries.Add(NewLib)

        'Add other library information here: --------------------------------------------------------------------------

    End Sub


    'Save the form settings if the form is being minimised:
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = &H112 Then 'SysCommand
            If m.WParam.ToInt32 = &HF020 Then 'Form is being minimised
                SaveFormSettings()
            End If
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub SaveProjectSettings()
        'Save the project settings in an XML file.
        'Add any Project Settings to be saved into the settingsData XDocument.
        Dim settingsData = <?xml version="1.0" encoding="utf-8"?>
                           <!---->
                           <!--Project settings for ADVL_Coordinates_1 application.-->
                           <ProjectSettings>
                           </ProjectSettings>

        Dim SettingsFileName As String = "ProjectSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"
        Project.SaveXmlSettings(SettingsFileName, settingsData)

    End Sub

    Private Sub RestoreProjectSettings()
        'Restore the project settings from an XML document.

        Dim SettingsFileName As String = "ProjectSettings_" & ApplicationInfo.Name & "_" & Me.Text & ".xml"

        If Project.SettingsFileExists(SettingsFileName) Then
            Dim Settings As System.Xml.Linq.XDocument
            Project.ReadXmlSettings(SettingsFileName, Settings)

            If IsNothing(Settings) Then 'There is no Settings XML data.
                Exit Sub
            End If

            'Restore a Project Setting example:
            If Settings.<ProjectSettings>.<Setting1>.Value = Nothing Then
                'Project setting not saved.
                'Setting1 = ""
            Else
                'Setting1 = Settings.<ProjectSettings>.<Setting1>.Value
            End If

            'Continue restoring saved settings.

        End If

    End Sub

#End Region 'Process XML Files ----------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Form Display Methods - Code used to display this form." '----------------------------------------------------------------------------------------------------------------------------

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Loading the Main form.

        'Set the Application Directory path: ------------------------------------------------
        Project.ApplicationDir = My.Application.Info.DirectoryPath.ToString

        'Read the Application Information file: ---------------------------------------------
        ApplicationInfo.ApplicationDir = My.Application.Info.DirectoryPath.ToString 'Set the Application Directory property

        ''Get the Application Version Information:
        'ApplicationInfo.Version.Major = My.Application.Info.Version.Major
        'ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
        'ApplicationInfo.Version.Build = My.Application.Info.Version.Build
        'ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision

        If ApplicationInfo.ApplicationLocked Then
            MessageBox.Show("The application is locked. If the application is not already in use, remove the 'Application_Info.lock file from the application directory: " & ApplicationInfo.ApplicationDir, "Notice", MessageBoxButtons.OK)
            Dim dr As System.Windows.Forms.DialogResult
            dr = MessageBox.Show("Press 'Yes' to unlock the application", "Notice", MessageBoxButtons.YesNo)
            If dr = System.Windows.Forms.DialogResult.Yes Then
                ApplicationInfo.UnlockApplication()
            Else
                Application.Exit()
                'System.Windows.Forms.Application.Exit()
                Exit Sub
            End If
        End If

        ReadApplicationInfo()

        'Read the Application Usage information: --------------------------------------------
        ApplicationUsage.StartTime = Now
        ApplicationUsage.SaveLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ApplicationUsage.SaveLocn.Path = Project.ApplicationDir
        ApplicationUsage.RestoreUsageInfo()

        'Restore Project information: -------------------------------------------------------
        Project.Application.Name = ApplicationInfo.Name

        'Set up Message object:
        Message.ApplicationName = ApplicationInfo.Name

        'Set up the Message object:
        Message.ApplicationName = ApplicationInfo.Name

        'Set up a temporary initial settings location:
        Dim TempLocn As New ADVL_Utilities_Library_1.FileLocation
        TempLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory
        TempLocn.Path = ApplicationInfo.ApplicationDir
        Message.SettingsLocn = TempLocn

        Me.Show() 'Show this form before showing the Message form - This will show the App icon on top in the TaskBar.

        'Start showing messages here - Message system is set up.
        Message.AddText("------------------- Starting Application: ADVL Application Template ----------------- " & vbCrLf, "Heading")
        'Message.AddText("Application usage: Total duration = " & Format(ApplicationUsage.TotalDuration.TotalHours, "#.##") & " hours" & vbCrLf, "Normal")
        Dim TotalDuration As String = ApplicationUsage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                           ApplicationUsage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                           ApplicationUsage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                           ApplicationUsage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"
        Message.AddText("Application usage: Total duration = " & TotalDuration & vbCrLf, "Normal")

        'https://msdn.microsoft.com/en-us/library/z2d603cy(v=vs.80).aspx#Y550
        'Process any command line arguments:
        Try
            For Each s As String In My.Application.CommandLineArgs
                Message.Add("Command line argument: " & vbCrLf)
                Message.AddXml(s & vbCrLf & vbCrLf)
                InstrReceived = s
            Next
        Catch ex As Exception
            Message.AddWarning("Error processing command line arguments: " & ex.Message & vbCrLf)
        End Try

        If ProjectSelected = False Then
            'Read the Settings Location for the last project used:
            Project.ReadLastProjectInfo()
            'The Last_Project_Info.xml file contains:
            '  Project Name and Description. Settings Location Type and Settings Location Path.
            'Message.Add("Last project info has been read." & vbCrLf)
            'Message.Add("Project.Type.ToString  " & Project.Type.ToString & vbCrLf)
            'Message.Add("Project.Path  " & Project.Path & vbCrLf)
            Message.Add("Last project details:" & vbCrLf)
            Message.Add("Project Type:  " & Project.Type.ToString & vbCrLf)
            Message.Add("Project Path:  " & Project.Path & vbCrLf)

            'At this point read the application start arguments, if any.
            'The selected project may be changed here.

            'Check if the project is locked:
            If Project.ProjectLocked Then
                Message.AddWarning("The project is locked: " & Project.Name & vbCrLf)
                Dim dr As System.Windows.Forms.DialogResult
                dr = MessageBox.Show("Press 'Yes' to unlock the project", "Notice", MessageBoxButtons.YesNo)
                If dr = System.Windows.Forms.DialogResult.Yes Then
                    'ApplicationInfo.UnlockApplication()
                    Project.UnlockProject()
                    Message.AddWarning("The project has been unlocked: " & Project.Name & vbCrLf)
                    'Read the Project Information file: -------------------------------------------------
                    Message.Add("Reading project info." & vbCrLf)
                    Project.ReadProjectInfoFile()                 'Read the file in the SettingsLocation: ADVL_Project_Info.xml

                    Project.ReadParameters()
                    Project.ReadParentParameters()
                    If Project.ParentParameterExists("ProNetName") Then
                        Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
                        ProNetName = Project.Parameter("ProNetName").Value
                    Else
                        ProNetName = Project.GetParameter("ProNetName")
                    End If
                    If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
                        Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
                        ProNetPath = Project.Parameter("ProNetPath").Value
                    Else
                        ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
                    End If
                    Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

                    Project.LockProject() 'Lock the project while it is open in this application.
                    'Set the project start time. This is used to track project usage.
                    Project.Usage.StartTime = Now
                    ApplicationInfo.SettingsLocn = Project.SettingsLocn
                    'Set up the Message object:
                    Message.SettingsLocn = Project.SettingsLocn
                    Message.Show()
                Else
                    'Application.Exit()
                    'Continue without any project selected.
                    Project.Name = ""
                    Project.Type = ADVL_Utilities_Library_1.Project.Types.None
                    Project.Description = ""
                    Project.SettingsLocn.Path = ""
                    Project.DataLocn.Path = ""
                End If
            Else
                'Read the Project Information file: -------------------------------------------------
                Message.Add("Reading project info." & vbCrLf)
                Project.ReadProjectInfoFile()                 'Read the file in the SettingsLocation: ADVL_Project_Info.xml

                Project.ReadParameters()
                Project.ReadParentParameters()
                If Project.ParentParameterExists("ProNetName") Then
                    Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
                    ProNetName = Project.Parameter("ProNetName").Value
                Else
                    ProNetName = Project.GetParameter("ProNetName")
                End If
                If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
                    Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
                    ProNetPath = Project.Parameter("ProNetPath").Value
                Else
                    ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
                End If
                Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

                Project.LockProject() 'Lock the project while it is open in this application.
                'Set the project start time. This is used to track project usage.
                Project.Usage.StartTime = Now
                ApplicationInfo.SettingsLocn = Project.SettingsLocn
                'Set up the Message object:
                Message.SettingsLocn = Project.SettingsLocn
                Message.Show() 'Added 18May19
            End If

        Else 'Project has been opened using Command Line arguments.

            Project.ReadParameters()
            Project.ReadParentParameters()
            If Project.ParentParameterExists("ProNetName") Then
                Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
                ProNetName = Project.Parameter("ProNetName").Value
            Else
                ProNetName = Project.GetParameter("ProNetName")
            End If
            If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
                Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
                ProNetPath = Project.Parameter("ProNetPath").Value
            Else
                ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
            End If
            Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

            Project.LockProject() 'Lock the project while it is open in this application.

            ProjectSelected = False 'Reset the Project Selected flag.
        End If


        'START Initialise the form: ===============================================================

        'Set up dgvMeasuredData:
        dgvMeasuredData.ColumnCount = 3
        If _depthUnit = DepthUnits.foot Then
            dgvMeasuredData.Columns(0).HeaderText = "Measured Depth" & vbCrLf & "(Feet RT)"
        Else
            dgvMeasuredData.Columns(0).HeaderText = "Measured Depth" & vbCrLf & "(" & _depthUnit.ToString & "s RT)"
        End If

        dgvMeasuredData.Columns(1).HeaderText = "Inclination" & vbCrLf & "(" & _angleUnit.ToString & "s)"
        dgvMeasuredData.Columns(2).HeaderText = "Azimuth" & vbCrLf & "(" & _angleUnit.ToString & "s)" & vbCrLf & " (" & _northReference.ToString & ")"
        dgvMeasuredData.AutoResizeColumns()

        dgvMeasuredData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        'dgvMeasuredData.


        'Set up dgvCalculatedData:
        dgvCalculatedData.ColumnCount = 6
        If _calcDepthUnit = DepthUnits.foot Then
            dgvCalculatedData.Columns(0).HeaderText = "True Vertical Depth" & vbCrLf & "(Feet RT)"
            dgvCalculatedData.Columns(3).HeaderText = "True Vertical Depth" & vbCrLf & "(Feet Subsea)"
        Else
            dgvCalculatedData.Columns(0).HeaderText = "True Vertical Depth" & vbCrLf & "(" & _calcDepthUnit.ToString & "s RT)"
            dgvCalculatedData.Columns(3).HeaderText = "True Vertical Depth" & vbCrLf & "(" & _calcDepthUnit.ToString & "s Subsea)"
        End If
        If _calcOffsetUnit = DistanceUnits.foot Then
            dgvCalculatedData.Columns(1).HeaderText = "dX" & vbCrLf & "(Feet)"
            dgvCalculatedData.Columns(2).HeaderText = "dY" & vbCrLf & "(Feet)"
            dgvCalculatedData.Columns(4).HeaderText = "Easting" & vbCrLf & "(Feet)"
            dgvCalculatedData.Columns(5).HeaderText = "Northing" & vbCrLf & "(Feet)"
        Else
            dgvCalculatedData.Columns(1).HeaderText = "dX" & vbCrLf & "(" & _calcOffsetUnit.ToString & "s)"
            dgvCalculatedData.Columns(2).HeaderText = "dY" & vbCrLf & "(" & _calcOffsetUnit.ToString & "s)"
            dgvCalculatedData.Columns(4).HeaderText = "Easting" & vbCrLf & "(" & _calcOffsetUnit.ToString & "s)"
            dgvCalculatedData.Columns(5).HeaderText = "Northing" & vbCrLf & "(" & _calcOffsetUnit.ToString & "s)"
        End If

        dgvCalculatedData.AutoResizeColumns()

        'Set up well path calculation method combo box:
        cmbCalcMethod.Items.Clear()
        cmbCalcMethod.Items.Add("Average Angle")
        cmbCalcMethod.Items.Add("Balanced Angle")
        cmbCalcMethod.Items.Add("Minimum Curvature")
        cmbCalcMethod.Items.Add("Radius of Curvature")
        cmbCalcMethod.Items.Add("Tangential")
        cmbCalcMethod.SelectedIndex = cmbCalcMethod.FindStringExact("Minimum Curvature")

        cmbMeasDepthUnit.Items.Clear()
        cmbMeasDepthUnit.Items.Add("Metres")
        cmbMeasDepthUnit.Items.Add("Feet")
        cmbMeasDepthUnit.SelectedIndex = cmbMeasDepthUnit.FindStringExact("Metres")

        cmbMeasAngleUnit.Items.Clear()
        cmbMeasAngleUnit.Items.Add("Degrees")
        cmbMeasAngleUnit.Items.Add("Radians")
        cmbMeasAngleUnit.SelectedIndex = cmbMeasAngleUnit.FindStringExact("Degrees")

        cmbMeasNorthReference.Items.Clear()
        cmbMeasNorthReference.Items.Add("Magnetic North")
        cmbMeasNorthReference.Items.Add("True North")
        cmbMeasNorthReference.Items.Add("Grid North")
        cmbMeasNorthReference.SelectedIndex = cmbMeasNorthReference.FindStringExact("Grid North")

        cmbCalcDepthUnit.Items.Clear()
        cmbCalcDepthUnit.Items.Add("Metres")
        cmbCalcDepthUnit.Items.Add("Feet")
        cmbCalcDepthUnit.SelectedIndex = cmbCalcDepthUnit.FindStringExact("Metres")

        txtCalcDepthDecPl.Text = "2"

        cmbCalcOffsetUnit.Items.Clear()
        cmbCalcOffsetUnit.Items.Add("Metres")
        cmbCalcOffsetUnit.Items.Add("Feet")
        cmbCalcOffsetUnit.SelectedIndex = cmbCalcOffsetUnit.FindStringExact("Metres")

        txtCalcOffsetDecPl.Text = "2"

        cmbInterpolationType.Items.Clear()
        cmbInterpolationType.Items.Add("Linear")
        cmbInterpolationType.Items.Add("Cubic Spline")
        cmbInterpolationType.SelectedIndex = cmbInterpolationType.FindStringExact("Cubic Spline")

        cmbInputDepth.Items.Clear()
        cmbInputDepth.Items.Add("Measured Depth RT")
        cmbInputDepth.Items.Add("Measured Depth Subsea")
        cmbInputDepth.SelectedIndex = cmbInputDepth.FindStringExact("Measured Depth Subsea")
        'Label39 units:
        If _depthUnit = DepthUnits.foot Then
            Label39.Text = "Feet"
            Label44.Text = "Feet"
            Label45.Text = "Feet"
        Else
            Label39.Text = _depthUnit.ToString & "s"
            Label44.Text = _depthUnit.ToString & "s"
            Label45.Text = _depthUnit.ToString & "s"
        End If

        If _calcOffsetUnit = DistanceUnits.foot Then
            Label50.Text = "Feet"
            Label51.Text = "Feet"
            Label46.Text = "Feet"
            Label47.Text = "Feet"
        Else
            Label50.Text = _calcOffsetUnit.ToString & "s"
            Label51.Text = _calcOffsetUnit.ToString & "s"
            Label46.Text = _calcOffsetUnit.ToString & "s"
            Label47.Text = _calcOffsetUnit.ToString & "s"
        End If



        cmbGeoCRS.Items.Clear()
        cmbProjCRS.Items.Clear()

        Me.WebBrowser1.ObjectForScripting = Me
        'IF THE LINE ABOVE PRODUCES AN ERROR ON STARTUP, CHECK THAT THE CODE ON THE FOLLOWING THREE LINES IS INSERTED JUST ABOVE THE Public Class Main STATEMENT.
        'Imports System.Security.Permissions
        '<PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
        '<System.Runtime.InteropServices.ComVisibleAttribute(True)>

        bgwSendMessage.WorkerReportsProgress = True
        bgwSendMessage.WorkerSupportsCancellation = True

        InitialiseForm() 'Initialise the form for a new project.

        'END   Initialise the form: ---------------------------------------------------------------


        RestoreFormSettings() 'Restore the form settings
        OpenStartPage()
        Message.ShowXMessages = ShowXMessages
        Message.ShowSysMessages = ShowSysMessages
        RestoreProjectSettings() 'Restore the Project settings

        ShowProjectInfo() 'Show the project information.

        Message.AddText("------------------- Started OK -------------------------------------------------------------------------- " & vbCrLf & vbCrLf, "Heading")

        If StartupConnectionName = "" Then

            If Project.ConnectOnOpen Then
                ConnectToComNet() 'The Project is set to connect when it is opened.
            ElseIf ApplicationInfo.ConnectOnStartup Then
                ConnectToComNet() 'The Application is set to connect when it is started.
            Else
                'Don't connect to ComNet.
            End If

        Else
            ConnectToComNet(StartupConnectionName)
        End If

        OpenWellDevFile(FileName)

        'Get the Application Version Information:
        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            'Application is network deployed.
            ApplicationInfo.Version.Number = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
            ApplicationInfo.Version.Major = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Major
            ApplicationInfo.Version.Minor = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor
            ApplicationInfo.Version.Build = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Build
            ApplicationInfo.Version.Revision = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision
            ApplicationInfo.Version.Source = "Publish"
            Message.Add("Application version: " & System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString & vbCrLf)
        Else
            'Application is not network deployed.
            ApplicationInfo.Version.Number = My.Application.Info.Version.ToString
            ApplicationInfo.Version.Major = My.Application.Info.Version.Major
            ApplicationInfo.Version.Minor = My.Application.Info.Version.Minor
            ApplicationInfo.Version.Build = My.Application.Info.Version.Build
            ApplicationInfo.Version.Revision = My.Application.Info.Version.Revision
            ApplicationInfo.Version.Source = "Assembly"
            Message.Add("Application version: " & My.Application.Info.Version.ToString & vbCrLf)
        End If

    End Sub


    Private Sub InitialiseForm()
        'Initialise the form for a new project.
        'OpenStartPage()
    End Sub

    Private Sub ShowProjectInfo()
        'Show the project information:

        txtProjectName.Text = Project.Name
        txtProNetName.Text = Project.GetParameter("ProNetName")
        txtProjectDescription.Text = Project.Description
        Select Case Project.Type
            Case ADVL_Utilities_Library_1.Project.Types.Directory
                txtProjectType.Text = "Directory"
            Case ADVL_Utilities_Library_1.Project.Types.Archive
                txtProjectType.Text = "Archive"
            Case ADVL_Utilities_Library_1.Project.Types.Hybrid
                txtProjectType.Text = "Hybrid"
            Case ADVL_Utilities_Library_1.Project.Types.None
                txtProjectType.Text = "None"
        End Select
        txtCreationDate.Text = Format(Project.Usage.FirstUsed, "d-MMM-yyyy H:mm:ss")
        txtLastUsed.Text = Format(Project.Usage.LastUsed, "d-MMM-yyyy H:mm:ss")
        txtProjectPath.Text = Project.Path

        Select Case Project.SettingsLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSettingsLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSettingsLocationType.Text = "Archive"
        End Select
        txtSettingsPath.Text = Project.SettingsLocn.Path

        Select Case Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtDataLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtDataLocationType.Text = "Archive"
        End Select
        txtDataPath.Text = Project.DataLocn.Path

        Select Case Project.SystemLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                txtSystemLocationType.Text = "Directory"
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                txtSystemLocationType.Text = "Archive"
        End Select
        txtSystemPath.Text = Project.SystemLocn.Path

        If Project.ConnectOnOpen Then
            chkConnect.Checked = True
        Else
            chkConnect.Checked = False
        End If

        'txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
        '                        Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
        '                        Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
        '                        Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c)

        'txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
        '                          Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

        txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                        Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                        Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                        Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                                  Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                                  Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                                  Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"

    End Sub




    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the Application

        'DisconnectFromAppNet() 'Disconnect from the Application Network.
        DisconnectFromComNet() 'Disconnect from the Communication Network.

        'SaveFormSettings() 'Save the settings of this form. 'THESE ARE SAVED WHEN THE FORM_CLOSING EVENT TRIGGERS.
        SaveProjectSettings() 'Save project settings.

        ApplicationInfo.WriteFile() 'Update the Application Information file.
        ApplicationInfo.UnlockApplication()

        Project.SaveLastProjectInfo() 'Save information about the last project used.

        Project.SaveParameters() 'ADDED 3Feb19

        'Project.SaveProjectInfoFile() 'Update the Project Information file. This is not required unless there is a change made to the project.

        Project.Usage.SaveUsageInfo() 'Save Project usage information.
        Project.UnlockProject() 'Unlock the project.

        ApplicationUsage.SaveUsageInfo() 'Save Application usage information.

        Application.Exit()

    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Save the form settings if the form state is normal. (A minimised form will have the incorrect size and location.)
        If WindowState = FormWindowState.Normal Then
            SaveFormSettings()
        End If
    End Sub


#End Region 'Form Display Methods -------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Open and Close Forms - Code used to open and close other forms." '-------------------------------------------------------------------------------------------------------------------

    Private Sub btnMessages_Click(sender As Object, e As EventArgs) Handles btnMessages.Click
        'Show the Messages form.
        Message.ApplicationName = ApplicationInfo.Name
        Message.SettingsLocn = Project.SettingsLocn
        Message.Show()
        Message.ShowXMessages = ShowXMessages
        Message.MessageForm.BringToFront()
    End Sub

    Private Sub btnGetGeoCRSList_Click(sender As Object, e As EventArgs) Handles btnGetGeoCRSList.Click
        'Open the Get CRS List form:
        If IsNothing(GetCRSListForm) Then
            GetCRSListForm = New frmGetCRSList
            GetCRSListForm.Show()
        Else
            GetCRSListForm.Show()
        End If
    End Sub

    Private Sub GetCRSListForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles GetCRSListForm.FormClosed
        GetCRSListForm = Nothing
    End Sub

    Private Sub btnGetProjCRSList_Click(sender As Object, e As EventArgs) Handles btnGetProjCRSList.Click
        'Open the Get CRS List form:
        If IsNothing(GetCRSListForm) Then
            GetCRSListForm = New frmGetCRSList
            GetCRSListForm.Show()
        Else
            GetCRSListForm.Show()
        End If
    End Sub

    Private Sub btnWebPages_Click(sender As Object, e As EventArgs) Handles btnWebPages.Click
        'Open the Web Pages form.

        If IsNothing(WebPageList) Then
            WebPageList = New frmWebPageList
            WebPageList.Show()
        Else
            WebPageList.Show()
            WebPageList.BringToFront()
        End If
    End Sub

    Private Sub WebPageList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles WebPageList.FormClosed
        WebPageList = Nothing
    End Sub

    Public Function OpenNewWebPage() As Integer
        'Open a new HTML Web View window, or reuse an existing one if avaiable.
        'The new forms index number in WebViewFormList is returned.

        NewWebPage = New frmWebPage
        If WebPageFormList.Count = 0 Then
            WebPageFormList.Add(NewWebPage)
            WebPageFormList(0).FormNo = 0
            WebPageFormList(0).Show
            Return 0 'The new HTML Display is at position 0 in WebViewFormList()
        Else
            Dim I As Integer
            Dim FormAdded As Boolean = False
            For I = 0 To WebPageFormList.Count - 1 'Check if there are closed forms in WebViewFormList. They can be re-used.
                If IsNothing(WebPageFormList(I)) Then
                    WebPageFormList(I) = NewWebPage
                    WebPageFormList(I).FormNo = I
                    WebPageFormList(I).Show
                    FormAdded = True
                    Return I 'The new Html Display is at position I in WebViewFormList()
                    Exit For
                End If
            Next
            If FormAdded = False Then 'Add a new form to WebViewFormList
                Dim FormNo As Integer
                WebPageFormList.Add(NewWebPage)
                FormNo = WebPageFormList.Count - 1
                WebPageFormList(FormNo).FormNo = FormNo
                WebPageFormList(FormNo).Show
                Return FormNo 'The new WebPage is at position FormNo in WebPageFormList()
            End If
        End If
    End Function

    Public Sub WebPageFormClosed()
        'This subroutine is called when the Web Page form has been closed.
        'The subroutine is usually called from the FormClosed event of the WebPage form.
        'The WebPage form may have multiple instances.
        'The ClosedFormNumber property should contains the number of the instance of the WebPage form.
        'This property should be updated by the WebPage form when it is being closed.
        'The ClosedFormNumber property value is used to determine which element in WebPageList should be set to Nothing.

        If WebPageFormList.Count < ClosedFormNo + 1 Then
            'ClosedFormNo is too large to exist in WebPageFormList
            Exit Sub
        End If

        If IsNothing(WebPageFormList(ClosedFormNo)) Then
            'The form is already set to nothing
        Else
            WebPageFormList(ClosedFormNo) = Nothing
        End If
    End Sub

    Public Function OpenNewHtmlDisplayPage() As Integer
        'Open a new HTML display window, or reuse an existing one if avaiable.
        'The new forms index number in HtmlDisplayFormList is returned.

        NewHtmlDisplay = New frmHtmlDisplay
        If HtmlDisplayFormList.Count = 0 Then
            HtmlDisplayFormList.Add(NewHtmlDisplay)
            HtmlDisplayFormList(0).FormNo = 0
            HtmlDisplayFormList(0).Show
            Return 0 'The new HTML Display is at position 0 in HtmlDisplayFormList()
        Else
            Dim I As Integer
            Dim FormAdded As Boolean = False
            For I = 0 To HtmlDisplayFormList.Count - 1 'Check if there are closed forms in HtmlDisplayFormList. They can be re-used.
                If IsNothing(HtmlDisplayFormList(I)) Then
                    HtmlDisplayFormList(I) = NewHtmlDisplay
                    HtmlDisplayFormList(I).FormNo = I
                    HtmlDisplayFormList(I).Show
                    FormAdded = True
                    Return I 'The new Html Display is at position I in HtmlDisplayFormList()
                    Exit For
                End If
            Next
            If FormAdded = False Then 'Add a new form to HtmlDisplayFormList
                Dim FormNo As Integer
                HtmlDisplayFormList.Add(NewHtmlDisplay)
                FormNo = HtmlDisplayFormList.Count - 1
                HtmlDisplayFormList(FormNo).FormNo = FormNo
                HtmlDisplayFormList(FormNo).Show
                Return FormNo 'The new HtmlDisplay is at position FormNo in HtmlDisplayFormList()
            End If
        End If
    End Function


#End Region 'Open and Close Forms -------------------------------------------------------------------------------------------------------------------------------------------------------------


#Region " Form Methods - The main actions performed by this form." '---------------------------------------------------------------------------------------------------------------------------

    Public Sub UpdateWebPage(ByVal FileName As String)
        'Update the web page in WebPageFormList if the Web file name is FileName.

        Dim NPages As Integer = WebPageFormList.Count
        Dim I As Integer

        Try
            For I = 0 To NPages - 1
                If IsNothing(WebPageFormList(I)) Then
                    'Web page has been deleted!
                Else
                    If WebPageFormList(I).FileName = FileName Then
                        WebPageFormList(I).OpenDocument
                    End If
                End If
            Next
        Catch ex As Exception
            Message.AddWarning(ex.Message & vbCrLf)
        End Try
    End Sub


    Private Sub btnParameters_Click(sender As Object, e As EventArgs) Handles btnParameters.Click
        Project.ShowParameters()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Add the current project to the Message Service list.

        If Project.ParentProjectName <> "" Then
            Message.AddWarning("This project has a parent: " & Project.ParentProjectName & vbCrLf)
            Message.AddWarning("Child projects can not be added to the list." & vbCrLf)
            Exit Sub
        End If

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    Dim Path As New XElement("Path", Project.Path)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to AppNet:
                    Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    client.SendMessage("", "MessageService", doc.ToString) 'UPDATED 2Feb19
                End If
            End If
        End If
    End Sub

    Private Sub btnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click
        If Project.Type = ADVL_Utilities_Library_1.Project.Types.Archive Then
            If IsNothing(ProjectArchive) Then
                ProjectArchive = New frmArchive
                ProjectArchive.Show()
                ProjectArchive.Title = "Project Archive"
                ProjectArchive.Path = Project.Path
            Else
                ProjectArchive.Show()
                ProjectArchive.BringToFront()
            End If
        Else
            Process.Start(Project.Path)
        End If
    End Sub

    Private Sub ProjectArchive_FormClosed(sender As Object, e As FormClosedEventArgs) Handles ProjectArchive.FormClosed
        ProjectArchive = Nothing
    End Sub

    Private Sub btnOpenSettings_Click(sender As Object, e As EventArgs) Handles btnOpenSettings.Click
        If Project.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.SettingsLocn.Path)
        ElseIf Project.SettingsLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive Then
            If IsNothing(SettingsArchive) Then
                SettingsArchive = New frmArchive
                SettingsArchive.Show()
                SettingsArchive.Title = "Settings Archive"
                SettingsArchive.Path = Project.SettingsLocn.Path
            Else
                SettingsArchive.Show()
                SettingsArchive.BringToFront()
            End If
        End If
    End Sub

    Private Sub SettingsArchive_FormClosed(sender As Object, e As FormClosedEventArgs) Handles SettingsArchive.FormClosed
        SettingsArchive = Nothing
    End Sub

    Private Sub btnOpenData_Click(sender As Object, e As EventArgs) Handles btnOpenData.Click
        If Project.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.DataLocn.Path)
        ElseIf Project.DataLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive Then
            If IsNothing(DataArchive) Then
                DataArchive = New frmArchive
                DataArchive.Show()
                DataArchive.Title = "Data Archive"
                DataArchive.Path = Project.DataLocn.Path
            Else
                DataArchive.Show()
                DataArchive.BringToFront()
            End If
        End If
    End Sub

    Private Sub DataArchive_FormClosed(sender As Object, e As FormClosedEventArgs) Handles DataArchive.FormClosed
        DataArchive = Nothing
    End Sub

    Private Sub btnOpenSystem_Click(sender As Object, e As EventArgs) Handles btnOpenSystem.Click
        If Project.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Directory Then
            Process.Start(Project.SystemLocn.Path)
        ElseIf Project.SystemLocn.Type = ADVL_Utilities_Library_1.FileLocation.Types.Archive Then
            If IsNothing(SystemArchive) Then
                SystemArchive = New frmArchive
                SystemArchive.Show()
                SystemArchive.Title = "System Archive"
                SystemArchive.Path = Project.SystemLocn.Path
            Else
                SystemArchive.Show()
                SystemArchive.BringToFront()
            End If
        End If
    End Sub

    Private Sub SystemArchive_FormClosed(sender As Object, e As FormClosedEventArgs) Handles SystemArchive.FormClosed
        SystemArchive = Nothing
    End Sub

    Private Sub btnOpenAppDir_Click(sender As Object, e As EventArgs) Handles btnOpenAppDir.Click
        Process.Start(ApplicationInfo.ApplicationDir)
    End Sub

    Private Sub btnShowProjectInfo_Click(sender As Object, e As EventArgs) Handles btnShowProjectInfo.Click
        'Show the current Project information:
        Message.Add("--------------------------------------------------------------------------------------" & vbCrLf)
        Message.Add("Project ------------------------ " & vbCrLf)
        Message.Add("   Name: " & Project.Name & vbCrLf)
        Message.Add("   Type: " & Project.Type.ToString & vbCrLf)
        Message.Add("   Description: " & Project.Description & vbCrLf)
        Message.Add("   Creation Date: " & Project.CreationDate & vbCrLf)
        Message.Add("   ID: " & Project.ID & vbCrLf)
        Message.Add("   Relative Path: " & Project.RelativePath & vbCrLf)
        Message.Add("   Path: " & Project.Path & vbCrLf & vbCrLf)

        Message.Add("Parent Project ----------------- " & vbCrLf)
        Message.Add("   Name: " & Project.ParentProjectName & vbCrLf)
        Message.Add("   Path: " & Project.ParentProjectPath & vbCrLf)

        Message.Add("Application -------------------- " & vbCrLf)
        Message.Add("   Name: " & Project.Application.Name & vbCrLf)
        Message.Add("   Description: " & Project.Application.Description & vbCrLf)
        Message.Add("   Path: " & Project.ApplicationDir & vbCrLf)

        Message.Add("Settings ----------------------- " & vbCrLf)
        Message.Add("   Settings Relative Location Type: " & Project.SettingsRelLocn.Type.ToString & vbCrLf)
        Message.Add("   Settings Relative Location Path: " & Project.SettingsRelLocn.Path & vbCrLf)
        Message.Add("   Settings Location Type: " & Project.SettingsLocn.Type.ToString & vbCrLf)
        Message.Add("   Settings Location Path: " & Project.SettingsLocn.Path & vbCrLf)

        Message.Add("Data --------------------------- " & vbCrLf)
        Message.Add("   Data Relative Location Type: " & Project.DataRelLocn.Type.ToString & vbCrLf)
        Message.Add("   Data Relative Location Path: " & Project.DataRelLocn.Path & vbCrLf)
        Message.Add("   Data Location Type: " & Project.DataLocn.Type.ToString & vbCrLf)
        Message.Add("   Data Location Path: " & Project.DataLocn.Path & vbCrLf)

        Message.Add("System ------------------------- " & vbCrLf)
        Message.Add("   System Relative Location Type: " & Project.SystemRelLocn.Type.ToString & vbCrLf)
        Message.Add("   System Relative Location Path: " & Project.SystemRelLocn.Path & vbCrLf)
        Message.Add("   System Location Type: " & Project.SystemLocn.Type.ToString & vbCrLf)
        Message.Add("   System Location Path: " & Project.SystemLocn.Path & vbCrLf)
        Message.Add("======================================================================================" & vbCrLf)

    End Sub

    Private Sub btnOpenParentDir_Click(sender As Object, e As EventArgs) Handles btnOpenParentDir.Click
        'Open the Parent directory of the selected project.
        Dim ParentDir As String = System.IO.Directory.GetParent(Project.Path).FullName
        If System.IO.Directory.Exists(ParentDir) Then
            Process.Start(ParentDir)
        Else
            Message.AddWarning("The parent directory was not found: " & ParentDir & vbCrLf)
        End If
    End Sub

    Private Sub btnCreateArchive_Click(sender As Object, e As EventArgs) Handles btnCreateArchive.Click
        'Create a Project Archive file.
        If Project.Type = ADVL_Utilities_Library_1.Project.Types.Archive Then
            Message.Add("The Project is an Archive type. It is already in an archived format." & vbCrLf)

        Else
            'The project is contained in the directory Project.Path.
            'This directory and contents will be saved in a zip file in the parent directory with the same name but with extension .AdvlArchive.

            Dim ParentDir As String = System.IO.Directory.GetParent(Project.Path).FullName
            Dim ProjectArchiveName As String = System.IO.Path.GetFileName(Project.Path) & ".AdvlArchive"

            If My.Computer.FileSystem.FileExists(ParentDir & "\" & ProjectArchiveName) Then 'The Project Archive file already exists.
                Message.Add("The Project Archive file already exists: " & ParentDir & "\" & ProjectArchiveName & vbCrLf)
            Else 'The Project Archive file does not exist. OK to create the Archive.
                System.IO.Compression.ZipFile.CreateFromDirectory(Project.Path, ParentDir & "\" & ProjectArchiveName)

                'Remove all Lock files:
                Dim Zip As System.IO.Compression.ZipArchive
                Zip = System.IO.Compression.ZipFile.Open(ParentDir & "\" & ProjectArchiveName, IO.Compression.ZipArchiveMode.Update)
                Dim DeleteList As New List(Of String) 'List of entry names to delete
                Dim myEntry As System.IO.Compression.ZipArchiveEntry
                For Each entry As System.IO.Compression.ZipArchiveEntry In Zip.Entries
                    If entry.Name = "Project.Lock" Then
                        DeleteList.Add(entry.FullName)
                    End If
                Next
                For Each item In DeleteList
                    myEntry = Zip.GetEntry(item)
                    myEntry.Delete()
                Next
                Zip.Dispose()

                Message.Add("Project Archive file created: " & ParentDir & "\" & ProjectArchiveName & vbCrLf)
            End If
        End If
    End Sub

    Private Sub btnOpenArchive_Click(sender As Object, e As EventArgs) Handles btnOpenArchive.Click
        'Open a Project Archive file.

        'Use the OpenFileDialog to look for an .AdvlArchive file.      
        OpenFileDialog1.Title = "Select an Archived Project File"
        OpenFileDialog1.InitialDirectory = System.IO.Directory.GetParent(Project.Path).FullName 'Start looking in the ParentDir.
        OpenFileDialog1.Filter = "Archived Project|*.AdvlArchive"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim FileName As String = OpenFileDialog1.FileName
            OpenArchivedProject(FileName)
        End If
    End Sub

    Private Sub OpenArchivedProject(ByVal FilePath As String)
        'Open the archived project at the specified path.

        Dim Zip As System.IO.Compression.ZipArchive
        Try
            Zip = System.IO.Compression.ZipFile.OpenRead(FilePath)

            Dim Entry As System.IO.Compression.ZipArchiveEntry = Zip.GetEntry("Project_Info_ADVL_2.xml")
            If IsNothing(Entry) Then
                Message.AddWarning("The file is not an Archived Andorville Project." & vbCrLf)
                'Check if it is an Archive project type with a .AdvlProject extension.
                'NOTE: These are already zip files so no need to archive.

            Else
                Message.Add("The file is an Archived Andorville Project." & vbCrLf)
                Dim ParentDir As String = System.IO.Directory.GetParent(FilePath).FullName
                Dim ProjectName As String = System.IO.Path.GetFileNameWithoutExtension(FilePath)
                Message.Add("The Project will be expanded in the directory: " & ParentDir & vbCrLf)
                Message.Add("The Project name will be: " & ProjectName & vbCrLf)
                Zip.Dispose()
                If System.IO.Directory.Exists(ParentDir & "\" & ProjectName) Then
                    Message.AddWarning("The Project already exists: " & ParentDir & "\" & ProjectName & vbCrLf)
                Else
                    System.IO.Compression.ZipFile.ExtractToDirectory(FilePath, ParentDir & "\" & ProjectName) 'Extract the project from the archive                   
                    Project.AddProjectToList(ParentDir & "\" & ProjectName)
                    'Open the new project                 
                    CloseProject()  'Close the current project
                    Project.SelectProject(ParentDir & "\" & ProjectName) 'Select the project at the specifed path.
                    OpenProject() 'Open the selected project.
                End If
            End If
        Catch ex As Exception
            Message.AddWarning("Error opening Archived Andorville Project: " & ex.Message & vbCrLf)
        End Try
    End Sub


    Private Sub TabPage1_DragEnter(sender As Object, e As DragEventArgs) Handles TabPage1.DragEnter
        'DragEnter: An object has been dragged into TabPage2 - Project Information tab.
        'This code is required to get the link to the item(s) being dragged into Project Information:
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        End If
    End Sub

    Private Sub TabPage1_DragDrop(sender As Object, e As DragEventArgs) Handles TabPage1.DragDrop
        'A file has been dropped into the Project Information tab.

        Dim Path As String()
        Path = e.Data.GetData(DataFormats.FileDrop)
        Dim I As Integer

        If Path.Count > 0 Then
            If Path.Count > 1 Then
                Message.AddWarning("More than one file has been dropped into the Project Information tab. Only the first one will be opened." & vbCrLf)
            End If

            Try
                Dim ArchivedProjectPath As String = Path(0)
                If ArchivedProjectPath.EndsWith(".AdvlArchive") Then
                    Message.Add("The archived project will be opened: " & vbCrLf & ArchivedProjectPath & vbCrLf)
                    OpenArchivedProject(ArchivedProjectPath)
                Else
                    Message.Add("The dropped file is not an archived project: " & vbCrLf & ArchivedProjectPath & vbCrLf)
                End If
            Catch ex As Exception
                Message.AddWarning("Error opening dropped archived project. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub
    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        'Update the current duration:
        'txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
        '                           Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
        '                           Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
        '                           Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                                   Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                                   Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                                   Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"

        Timer2.Interval = 5000 '5 seconds
        Timer2.Enabled = True
        Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Update the current duration:
        'txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
        '              Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
        '              Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
        '              Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                           Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                           Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                           Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"
    End Sub

    Private Sub TabPage1_Leave(sender As Object, e As EventArgs) Handles TabPage1.Leave
        Timer2.Enabled = False
    End Sub



#Region " Start Page Code" '=========================================================================================================================================

    Public Sub OpenStartPage()
        'Open the workflow page:

        If Project.DataFileExists(WorkflowFileName) Then
            'Note: WorkflowFileName should have been restored when the application started.
            DisplayWorkflow()
        ElseIf Project.DataFileExists("StartPage.html") Then
            WorkflowFileName = "StartPage.html"
            DisplayWorkflow()
        Else
            CreateStartPage()
            WorkflowFileName = "StartPage.html"
            DisplayWorkflow()
        End If

        ''Open the StartPage.html file and display in the Workflow tab.
        'If Project.DataFileExists("StartPage.html") Then
        '    WorkflowFileName = "StartPage.html"
        '    DisplayWorkflow()
        'Else
        '    CreateStartPage()
        '    WorkflowFileName = "StartPage.html"
        '    DisplayWorkflow()
        'End If
    End Sub

    Public Sub DisplayWorkflow()
        'Display the StartPage.html file in the Start Page tab.

        If Project.DataFileExists(WorkflowFileName) Then
            Dim rtbData As New IO.MemoryStream
            Project.ReadData(WorkflowFileName, rtbData)
            rtbData.Position = 0
            Dim sr As New IO.StreamReader(rtbData)
            WebBrowser1.DocumentText = sr.ReadToEnd()
        Else
            Message.AddWarning("Web page file not found: " & WorkflowFileName & vbCrLf)
        End If
    End Sub

    Private Sub CreateStartPage()
        'Create a new default StartPage.html file.

        Dim htmData As New IO.MemoryStream
        Dim sw As New IO.StreamWriter(htmData)
        sw.Write(AppInfoHtmlString("Application Information")) 'Create a web page providing information about the application.
        sw.Flush()
        Project.SaveData("StartPage.html", htmData)
    End Sub

    Public Function AppInfoHtmlString(ByVal DocumentTitle As String) As String
        'Create an Application Information Web Page.

        'This function should be edited to provide a brief description of the Application.

        Dim sb As New System.Text.StringBuilder

        sb.Append("<!DOCTYPE html>" & vbCrLf)
        sb.Append("<html>" & vbCrLf)
        sb.Append("<head>" & vbCrLf)
        sb.Append("<title>" & DocumentTitle & "</title>" & vbCrLf)
        sb.Append("<meta name=""description"" content=""Application information."">" & vbCrLf)
        sb.Append("</head>" & vbCrLf)

        sb.Append("<body style=""font-family:arial;"">" & vbCrLf & vbCrLf)

        sb.Append("<h2>" & "Andorville&trade; Well Deviation" & "</h2>" & vbCrLf & vbCrLf) 'Add the page title.
        sb.Append("<hr>" & vbCrLf) 'Add a horizontal divider line.
        sb.Append("<p>The Well Deviation application stores, processes and displays well deviation data.</p>" & vbCrLf) 'Add an application description.
        sb.Append("<hr>" & vbCrLf & vbCrLf) 'Add a horizontal divider line.

        sb.Append(DefaultJavaScriptString)

        sb.Append("</body>" & vbCrLf)
        sb.Append("</html>" & vbCrLf)

        Return sb.ToString

    End Function

    Public Function DefaultJavaScriptString() As String
        'Generate the default JavaScript section of an Andorville(TM) Workflow Web Page.

        Dim sb As New System.Text.StringBuilder

        'Add JavaScript section:
        sb.Append("<script>" & vbCrLf & vbCrLf)

        'START: User defined JavaScript functions ==========================================================================
        'Add functions to implement the main actions performed by this web page.
        sb.Append("//START: User defined JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Add functions to implement the main actions performed by this web page." & vbCrLf & vbCrLf)

        sb.Append("//END:   User defined JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User defined JavaScript functions --------------------------------------------------------------------------


        'START: User modified JavaScript functions ==========================================================================
        'Modify these function to save all required web page settings and process all expected XMessage instructions.
        sb.Append("//START: User modified JavaScript functions ==========================================================================" & vbCrLf)
        sb.Append("//  Modify these function to save all required web page settings and process all expected XMessage instructions." & vbCrLf & vbCrLf)

        'Add the SaveSettings function - This is used to save web page settings between sessions.
        sb.Append("//Save the web page settings." & vbCrLf)
        sb.Append("function SaveSettings() {" & vbCrLf)
        sb.Append("  var xSettings = ""<Settings>"" + "" \n"" ; //String containing the web page settings in XML format." & vbCrLf)
        sb.Append("  //Add xml lines to save each setting." & vbCrLf & vbCrLf)
        sb.Append("  xSettings +=    ""</Settings>"" + ""\n"" ; //End of the Settings element." & vbCrLf)
        sb.Append(vbCrLf)
        sb.Append("  //Save the settings as an XML file in the project." & vbCrLf)
        sb.Append("  window.external.SaveHtmlSettings(xSettings) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Process a single XMsg instruction (Information:Location pair)
        sb.Append("//Process an XMessage instruction:" & vbCrLf)
        sb.Append("function XMsgInstruction(Info, Locn) {" & vbCrLf)
        sb.Append("  switch(Locn) {" & vbCrLf)
        sb.Append("  //Insert case statements here." & vbCrLf)
        sb.Append("  default:" & vbCrLf)
        sb.Append("    window.external.AddWarning(""Unknown location: "" + Locn + ""\r\n"") ;" & vbCrLf)
        sb.Append("  }" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   User modified JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf & vbCrLf)
        'END:   User modified JavaScript functions --------------------------------------------------------------------------

        'START: Required Document Library Web Page JavaScript functions ==========================================================================
        sb.Append("//START: Required Document Library Web Page JavaScript functions ==========================================================================" & vbCrLf & vbCrLf)

        'Add the AddText function - This sends a message to the message window using a named text type.
        sb.Append("//Add text to the Message window using a named txt type:" & vbCrLf)
        sb.Append("function AddText(Msg, TextType) {" & vbCrLf)
        sb.Append("  window.external.AddText(Msg, TextType) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddMessage function - This sends a message to the message window using default black text.
        sb.Append("//Add a message to the Message window using the default black text:" & vbCrLf)
        sb.Append("function AddMessage(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddMessage(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the AddWarning function - This sends a red, bold warning message to the message window.
        sb.Append("//Add a warning message to the Message window using bold red text:" & vbCrLf)
        sb.Append("function AddWarning(Msg) {" & vbCrLf)
        sb.Append("  window.external.AddWarning(Msg) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreSettings function - This is used to restore web page settings.
        sb.Append("//Restore the web page settings." & vbCrLf)
        sb.Append("function RestoreSettings() {" & vbCrLf)
        sb.Append("  window.external.RestoreHtmlSettings() " & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'This line runs the RestoreSettings function when the web page is loaded.
        sb.Append("//Restore the web page settings when the page loads." & vbCrLf)
        sb.Append("window.onload = RestoreSettings; " & vbCrLf)
        sb.Append(vbCrLf)

        'Restores a single setting on the web page.
        sb.Append("//Restore a web page setting." & vbCrLf)
        sb.Append("  function RestoreSetting(FormName, ItemName, ItemValue) {" & vbCrLf)
        sb.Append("  document.forms[FormName][ItemName].value = ItemValue ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        'Add the RestoreOption function - This is used to add an option to a Select list.
        sb.Append("//Restore a Select control Option." & vbCrLf)
        sb.Append("function RestoreOption(SelectId, OptionText) {" & vbCrLf)
        sb.Append("  var x = document.getElementById(SelectId) ;" & vbCrLf)
        sb.Append("  var option = document.createElement(""Option"") ;" & vbCrLf)
        sb.Append("  option.text = OptionText ;" & vbCrLf)
        sb.Append("  x.add(option) ;" & vbCrLf)
        sb.Append("}" & vbCrLf)
        sb.Append(vbCrLf)

        sb.Append("//END:   Required Document Library Web Page JavaScript functions __________________________________________________________________________" & vbCrLf & vbCrLf)
        'END:   Required Document Library Web Page JavaScript functions --------------------------------------------------------------------------

        sb.Append("</script>" & vbCrLf & vbCrLf)

        Return sb.ToString

    End Function


    Public Function DefaultHtmlString(ByVal DocumentTitle As String) As String
        'Create a blank HTML Web Page.

        Dim sb As New System.Text.StringBuilder

        sb.Append("<!DOCTYPE html>" & vbCrLf)
        sb.Append("<html>" & vbCrLf)
        sb.Append("<!-- Andorville(TM) Workflow File -->" & vbCrLf)
        sb.Append("<!-- Application Name:    " & ApplicationInfo.Name & " -->" & vbCrLf)
        sb.Append("<!-- Application Version: " & My.Application.Info.Version.ToString & " -->" & vbCrLf)
        sb.Append("<!-- Creation Date:          " & Format(Now, "dd MMMM yyyy") & " -->" & vbCrLf)
        sb.Append("<head>" & vbCrLf)
        sb.Append("<title>" & DocumentTitle & "</title>" & vbCrLf)
        sb.Append("<meta name=""description"" content=""Workflow description."">" & vbCrLf)
        sb.Append("</head>" & vbCrLf)

        sb.Append("<body style=""font-family:arial;"">" & vbCrLf & vbCrLf)

        sb.Append("<h1>" & DocumentTitle & "</h1>" & vbCrLf & vbCrLf)

        sb.Append(DefaultJavaScriptString)

        sb.Append("</body>" & vbCrLf)
        sb.Append("</html>" & vbCrLf)

        Return sb.ToString

    End Function

#End Region 'Start Page Code ------------------------------------------------------------------------------------------------------------------------------------------------------------------

#Region " Methods Called by JavaScript - A collection of methods that can be called by JavaScript in a web page shown in WebBrowser1" '==================================
    'These methods are used to display HTML pages in the Document tab.
    'The same methods can be found in the WebView form, which displays web pages on seprate forms.


    'Display Messages ==============================================================================================

    Public Sub AddMessage(ByVal Msg As String)
        'Add a normal text message to the Message window.
        Message.Add(Msg)
    End Sub

    Public Sub AddWarning(ByVal Msg As String)
        'Add a warning text message to the Message window.
        Message.AddWarning(Msg)
    End Sub

    Public Sub AddTextTypeMessage(ByVal Msg As String, ByVal TextType As String)
        'Add a message with the specified Text Type to the Message window.
        Message.AddText(Msg, TextType)
    End Sub

    Public Sub AddXmlMessage(ByVal XmlText As String)
        'Add an Xml message to the Message window.
        Message.AddXml(XmlText)
    End Sub

    'END Display Messages ------------------------------------------------------------------------------------------


    'Run an XSequence ==============================================================================================

    Public Sub RunClipboardXSeq()
        'Run the XSequence instructions in the clipboard.

        Dim XDocSeq As System.Xml.Linq.XDocument
        Try
            XDocSeq = XDocument.Parse(My.Computer.Clipboard.GetText)
        Catch ex As Exception
            Message.AddWarning("Error reading Clipboard data. " & ex.Message & vbCrLf)
            Exit Sub
        End Try

        If IsNothing(XDocSeq) Then
            Message.Add("No XSequence instructions were found in the clipboard.")
        Else
            Dim XmlSeq As New System.Xml.XmlDocument
            Try
                XmlSeq.LoadXml(XDocSeq.ToString) 'Convert XDocSeq to an XmlDocument to process with XSeq.
                'Run the sequence:
                XSeq.RunXSequence(XmlSeq, Status)
            Catch ex As Exception
                Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub RunXSequence(ByVal XSequence As String)
        'Run the XMSequence
        Dim XmlSeq As New System.Xml.XmlDocument
        XmlSeq.LoadXml(XSequence)
        XSeq.RunXSequence(XmlSeq, Status)
    End Sub

    Private Sub XSeq_ErrorMsg(ErrMsg As String) Handles XSeq.ErrorMsg
        Message.AddWarning(ErrMsg & vbCrLf)
    End Sub


    Private Sub XSeq_Instruction(Data As String, Locn As String) Handles XSeq.Instruction
        'Execute each instruction produced by running the XSeq file.

        Select Case Locn
            Case "Settings:Form:Name"
                FormName = Data

            Case "Settings:Form:Item:Name"
                ItemName = Data

            Case "Settings:Form:Item:Value"
                RestoreSetting(FormName, ItemName, Data)

            Case "Settings:Form:SelectId"
                SelectId = Data

            Case "Settings:Form:OptionText"
                RestoreOption(SelectId, Data)

            ''Start Project commands: ----------------------------------------------------
            'Case "StartProject:AppName"
            '    StartProject_AppName = Data

            'Case "StartProject:ConnectionName"
            '    StartProject_ConnName = Data

            'Case "StartProject:ProjectID"
            '    StartProject_ProjID = Data

            'Case "StartProject:Command"
            '    Select Case Data
            '        Case "Apply"
            '            StartApp_ProjectID(StartProject_AppName, StartProject_ProjID, StartProject_ConnName)
            '        Case Else
            '            Message.AddWarning("Unknown Start Project command : " & Data & vbCrLf)
            '    End Select

            ''END Start project commands ---------------------------------------------



            Case "Settings"

            Case "EndOfSequence"
                'Main.Message.Add("End of processing sequence" & Data & vbCrLf)

            Case Else
                'Main.Message.AddWarning("Unknown location: " & Locn & "  Data: " & Data & vbCrLf)
                Message.AddWarning("Unknown location: " & Locn & "  Data: " & Data & vbCrLf)

        End Select
    End Sub

    'END Run an XSequence ------------------------------------------------------------------------------------------


    'Run an XMessage ===============================================================================================

    Public Sub RunXMessage(ByVal XMsg As String)
        'Run the XMessage by sending it to InstrReceived.
        InstrReceived = XMsg
    End Sub

    Public Sub SendXMessage(ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMessage to the application with the connection name ConnName.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                If bgwSendMessage.IsBusy Then
                    Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                Else
                    Dim SendMessageParams As New clsSendMessageParams
                    SendMessageParams.ProjectNetworkName = ProNetName
                    SendMessageParams.ConnectionName = ConnName
                    SendMessageParams.Message = XMsg
                    bgwSendMessage.RunWorkerAsync(SendMessageParams)
                    If ShowXMessages Then
                        Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                        Message.XAddXml(XMsg)
                        Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub SendXMessageExt(ByVal ProNetName As String, ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMsg to the application with the connection name ConnName and Project Network Name ProNetname.
        'This version can send the XMessage to a connection external to the current Project Network.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                If bgwSendMessage.IsBusy Then
                    Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                Else
                    Dim SendMessageParams As New clsSendMessageParams
                    SendMessageParams.ProjectNetworkName = ProNetName
                    SendMessageParams.ConnectionName = ConnName
                    SendMessageParams.Message = XMsg
                    bgwSendMessage.RunWorkerAsync(SendMessageParams)
                    If ShowXMessages Then
                        Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                        Message.XAddXml(XMsg)
                        Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub SendXMessageWait(ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMsg to the application with the connection name ConnName.
        'Wait for the connection to be made.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            Try
                'Application.DoEvents() 'TRY THE METHOD WITHOUT THE DOEVENTS
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("client state is faulted. Message not sent!" & vbCrLf)
                Else
                    Dim StartTime As Date = Now
                    Dim Duration As TimeSpan
                    'Wait up to 16 seconds for the connection ConnName to be established
                    While client.ConnectionExists(ProNetName, ConnName) = False 'Wait until the required connection is made.
                        System.Threading.Thread.Sleep(1000) 'Pause for 1000ms
                        Duration = Now - StartTime
                        If Duration.Seconds > 16 Then Exit While
                    End While

                    If client.ConnectionExists(ProNetName, ConnName) = False Then
                        Message.AddWarning("Connection not available: " & ConnName & " in application network: " & ProNetName & vbCrLf)
                    Else
                        If bgwSendMessage.IsBusy Then
                            Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                        Else
                            Dim SendMessageParams As New clsSendMessageParams
                            SendMessageParams.ProjectNetworkName = ProNetName
                            SendMessageParams.ConnectionName = ConnName
                            SendMessageParams.Message = XMsg
                            bgwSendMessage.RunWorkerAsync(SendMessageParams)
                            If ShowXMessages Then
                                Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                                Message.XAddXml(XMsg)
                                Message.XAddText(vbCrLf, "Normal") 'Add extra line
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Message.AddWarning(ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub SendXMessageExtWait(ByVal ProNetName As String, ByVal ConnName As String, ByVal XMsg As String)
        'Send the XMsg to the application with the connection name ConnName and Project Network Name ProNetName.
        'Wait for the connection to be made.
        'This version can send the XMessage to a connection external to the current Project Network.
        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                Dim StartTime As Date = Now
                Dim Duration As TimeSpan
                'Wait up to 16 seconds for the connection ConnName to be established
                While client.ConnectionExists(ProNetName, ConnName) = False
                    System.Threading.Thread.Sleep(1000) 'Pause for 1000ms
                    Duration = Now - StartTime
                    If Duration.Seconds > 16 Then Exit While
                End While

                If client.ConnectionExists(ProNetName, ConnName) = False Then
                    Message.AddWarning("Connection not available: " & ConnName & " in application network: " & ProNetName & vbCrLf)
                Else
                    If bgwSendMessage.IsBusy Then
                        Message.AddWarning("Send Message backgroundworker is busy." & vbCrLf)
                    Else
                        Dim SendMessageParams As New clsSendMessageParams
                        SendMessageParams.ProjectNetworkName = ProNetName
                        SendMessageParams.ConnectionName = ConnName
                        SendMessageParams.Message = XMsg
                        bgwSendMessage.RunWorkerAsync(SendMessageParams)
                        If ShowXMessages Then
                            Message.XAddText("Message sent to " & "[" & ProNetName & "]." & ConnName & ":" & vbCrLf, "XmlSentNotice")
                            Message.XAddXml(XMsg)
                            Message.XAddText(vbCrLf, "Normal") 'Add extra line
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub XMsgInstruction(ByVal Info As String, ByVal Locn As String)
        'Send the XMessage Instruction to the JavaScript function XMsgInstruction for processing.
        Me.WebBrowser1.Document.InvokeScript("XMsgInstruction", New String() {Info, Locn})
    End Sub

    'END Run an XMessage -------------------------------------------------------------------------------------------


    'Get Information ===============================================================================================

    Public Function GetFormNo() As String
        'Return FormNo.ToString
        Return "-1"
    End Function

    Public Function GetParentFormNo() As String
        'Return the Form Number of the Parent Form (that called this form).
        'Return ParentWebPageFormNo.ToString
        Return "-1" 'The Main Form does not have a Parent Web Page.
    End Function

    Public Function GetConnectionName() As String
        'Return the Connection Name of the Project.
        Return ConnectionName
    End Function

    Public Function GetProNetName() As String
        'Return the Project Network Name of the Project.
        Return ProNetName
    End Function

    Public Sub ParentProjectName(ByVal FormName As String, ByVal ItemName As String)
        'Return the Parent Project name:
        RestoreSetting(FormName, ItemName, Project.ParentProjectName)
    End Sub

    Public Sub ParentProjectPath(ByVal FormName As String, ByVal ItemName As String)
        'Return the Parent Project path:
        RestoreSetting(FormName, ItemName, Project.ParentProjectPath)
    End Sub

    Public Sub ParentProjectParameterValue(ByVal FormName As String, ByVal ItemName As String, ByVal ParameterName As String)
        'Return the specified Parent Project parameter value:
        RestoreSetting(FormName, ItemName, Project.ParentParameter(ParameterName).Value)
    End Sub

    Public Sub ProjectParameterValue(ByVal FormName As String, ByVal ItemName As String, ByVal ParameterName As String)
        'Return the specified Project parameter value:
        RestoreSetting(FormName, ItemName, Project.Parameter(ParameterName).Value)
    End Sub

    Public Sub ProjectNetworkName(ByVal FormName As String, ByVal ItemName As String)
        'Return the name of the Project Network:
        RestoreSetting(FormName, ItemName, Project.Parameter("ProNetName").Value)
    End Sub

    'END Get Information -------------------------------------------------------------------------------------------


    'Open a Web Page ===============================================================================================

    Public Sub OpenWebPage(ByVal FileName As String)
        'Open the web page with the specified File Name.

        If FileName = "" Then

        Else
            'First check if the HTML file is already open:
            Dim FileFound As Boolean = False
            If WebPageFormList.Count = 0 Then

            Else
                Dim I As Integer
                For I = 0 To WebPageFormList.Count - 1
                    If WebPageFormList(I) Is Nothing Then

                    Else
                        If WebPageFormList(I).FileName = FileName Then
                            FileFound = True
                            WebPageFormList(I).BringToFront
                        End If
                    End If
                Next
            End If

            If FileFound = False Then
                Dim FormNo As Integer = OpenNewWebPage()
                WebPageFormList(FormNo).FileName = FileName
                WebPageFormList(FormNo).OpenDocument
                WebPageFormList(FormNo).BringToFront
            End If
        End If
    End Sub

    'END Open a Web Page -------------------------------------------------------------------------------------------


    'Open and Close Projects =======================================================================================

    Public Sub OpenProjectAtRelativePath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Open the Project at the specified Relative Path using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            ProjectPath = Project.Path & RelativePath
            client.StartProjectAtPath(ProjectPath, ConnectionName)
        Else
            ProjectPath = Project.Path & "\" & RelativePath
            client.StartProjectAtPath(ProjectPath, ConnectionName)
        End If
    End Sub

    Public Sub CheckOpenProjectAtRelativePath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Check if the project at the specified Relative Path is open.
        'Open it if it is not already open.
        'Open the Project at the specified Relative Path using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            ProjectPath = Project.Path & RelativePath
            If client.ProjectOpen(ProjectPath) Then
                'Project is already open.
            Else
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            End If
        Else
            ProjectPath = Project.Path & "\" & RelativePath
            If client.ProjectOpen(ProjectPath) Then
                'Project is already open.
            Else
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            End If
        End If
    End Sub

    Public Sub OpenProjectAtProNetPath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Open the Project at the specified Path (relative to the Project Network Path) using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & RelativePath
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        Else
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & "\" & RelativePath
                client.StartProjectAtPath(ProjectPath, ConnectionName)
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        End If
    End Sub

    Public Sub CheckOpenProjectAtProNetPath(ByVal RelativePath As String, ByVal ConnectionName As String)
        'Check if the project at the specified Path (relative to the Project Network Path) is open.
        'Open it if it is not already open.
        'Open the Project at the specified Path using the specified Connection Name.

        Dim ProjectPath As String
        If RelativePath.StartsWith("\") Then
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & RelativePath
                'client.StartProjectAtPath(ProjectPath, ConnectionName)
                If client.ProjectOpen(ProjectPath) Then
                    'Project is already open.
                Else
                    client.StartProjectAtPath(ProjectPath, ConnectionName)
                End If
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        Else
            If Project.ParameterExists("ProNetPath") Then
                ProjectPath = Project.GetParameter("ProNetPath") & "\" & RelativePath
                'client.StartProjectAtPath(ProjectPath, ConnectionName)
                If client.ProjectOpen(ProjectPath) Then
                    'Project is already open.
                Else
                    client.StartProjectAtPath(ProjectPath, ConnectionName)
                End If
            Else
                Message.AddWarning("The Project Network Path is not known." & vbCrLf)
            End If
        End If
    End Sub

    Public Sub CloseProjectAtConnection(ByVal ProNetName As String, ByVal ConnectionName As String)
        'Close the Project at the specified connection.

        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                'Create the XML instructions to close the application at the connection.
                Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class

                'NOTE: No reply expected. No need to provide the following client information(?)
                'Dim clientConnName As New XElement("ClientConnectionName", Me.ConnectionName)
                'xmessage.Add(clientConnName)

                Dim command As New XElement("Command", "Close")
                xmessage.Add(command)
                doc.Add(xmessage)

                'Show the message sent:
                Message.XAddText("Message sent to: [" & ProNetName & "]." & ConnectionName & ":" & vbCrLf, "XmlSentNotice")
                Message.XAddXml(doc.ToString)
                Message.XAddText(vbCrLf, "Normal") 'Add extra line

                client.SendMessage(ProNetName, ConnectionName, doc.ToString)
            End If
        End If
    End Sub

    'END Open and Close Projects -----------------------------------------------------------------------------------


    'System Methods ================================================================================================

    Public Sub SaveHtmlSettings(ByVal xSettings As String, ByVal FileName As String)
        'Save the Html settings for a web page.

        'Convert the XSettings to XML format:
        Dim XmlHeader As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>"
        Dim XDocSettings As New System.Xml.Linq.XDocument

        Try
            XDocSettings = System.Xml.Linq.XDocument.Parse(XmlHeader & vbCrLf & xSettings)
        Catch ex As Exception
            Message.AddWarning("Error saving HTML settings file. " & ex.Message & vbCrLf)
        End Try

        Project.SaveXmlData(FileName, XDocSettings)
    End Sub

    Public Sub RestoreHtmlSettings()
        'Restore the Html settings for a web page.

        Dim SettingsFileName As String = WorkflowFileName & "Settings"

        Dim XDocSettings As New System.Xml.Linq.XDocument
        Project.ReadXmlData(SettingsFileName, XDocSettings)

        If XDocSettings Is Nothing Then
            'Message.Add("No HTML Settings file : " & SettingsFileName & vbCrLf)
        Else
            Dim XSettings As New System.Xml.XmlDocument
            Try
                XSettings.LoadXml(XDocSettings.ToString)
                'Run the Settings file:
                XSeq.RunXSequence(XSettings, Status)
            Catch ex As Exception
                Message.AddWarning("Error restoring HTML settings. " & ex.Message & vbCrLf)
            End Try
        End If
    End Sub

    Public Sub RestoreSetting(ByVal FormName As String, ByVal ItemName As String, ByVal ItemValue As String)
        'Restore the setting value with the specified Form Name and Item Name.
        Me.WebBrowser1.Document.InvokeScript("RestoreSetting", New String() {FormName, ItemName, ItemValue})
    End Sub

    Public Sub RestoreOption(ByVal SelectId As String, ByVal OptionText As String)
        'Restore the Option text in the Select control with the Id SelectId.
        Me.WebBrowser1.Document.InvokeScript("RestoreOption", New String() {SelectId, OptionText})
    End Sub

    Private Sub SaveWebPageSettings()
        'Call the SaveSettings JavaScript function:
        Try
            Me.WebBrowser1.Document.InvokeScript("SaveSettings")
        Catch ex As Exception
            Message.AddWarning("Web page settings not saved: " & ex.Message & vbCrLf)
        End Try
    End Sub

    'END System Methods --------------------------------------------------------------------------------------------


    'Legacy Code (These methods should no longer be used) ==========================================================

    Public Sub JSMethodTest1()
        'Test method that is called from JavaScript.
        Message.Add("JSMethodTest1 called OK." & vbCrLf)
    End Sub

    Public Sub JSMethodTest2(ByVal Var1 As String, ByVal Var2 As String)
        'Test method that is called from JavaScript.
        Message.Add("Var1 = " & Var1 & " Var2 = " & Var2 & vbCrLf)
    End Sub

    Public Sub JSDisplayXml(ByRef XDoc As XDocument)
        Message.Add(XDoc.ToString & vbCrLf & vbCrLf)
    End Sub

    Public Sub ShowMessage(ByVal Msg As String)
        Message.Add(Msg)
    End Sub

    Public Sub AddText(ByVal Msg As String, ByVal TextType As String)
        Message.AddText(Msg, TextType)
    End Sub

    'END Legacy Code -----------------------------------------------------------------------------------------------


#End Region 'Methods Called by JavaScript -------------------------------------------------------------------------------------------------------------------------------




    Private Sub btnProject_Click(sender As Object, e As EventArgs) Handles btnProject.Click
        Project.SelectProject()
    End Sub

    Private Sub btnAppInfo_Click(sender As Object, e As EventArgs) Handles btnAppInfo.Click
        ApplicationInfo.ShowInfo()
    End Sub

    Private Sub btnAndorville_Click(sender As Object, e As EventArgs) Handles btnAndorville.Click
        ApplicationInfo.ShowInfo()
    End Sub

    'Project Events:
    Private Sub Project_Message(Msg As String) Handles Project.Message
        'Display the Project message:
        Message.Add(Msg & vbCrLf)
    End Sub

    Private Sub Project_ErrorMessage(Msg As String) Handles Project.ErrorMessage
        'Display the Project error message:
        Message.SetWarningStyle()
        Message.Add(Msg & vbCrLf)
        Message.SetNormalStyle()
    End Sub

    Private Sub Project_Closing() Handles Project.Closing
        'The current project is closing.
        CloseProject()
        'SaveFormSettings() 'Save the form settings - they are saved in the Project before is closes.
        'SaveProjectSettings() 'Update this subroutine if project settings need to be saved.
        'Project.Usage.SaveUsageInfo() 'Save the current project usage information.
        'Project.UnlockProject() 'Unlock the current project before it Is closed.
        'If ConnectedToComNet Then DisconnectFromComNet()
    End Sub

    Private Sub CloseProject()
        'Close the Project:
        SaveFormSettings() 'Save the form settings - they are saved in the Project before is closes.
        SaveProjectSettings() 'Update this subroutine if project settings need to be saved.
        Project.Usage.SaveUsageInfo() 'Save the current project usage information.
        Project.UnlockProject() 'Unlock the current project before it Is closed.
        If ConnectedToComNet Then DisconnectFromComNet() 'ADDED 9Apr20
    End Sub

    Private Sub Project_Selected() Handles Project.Selected
        'A new project has been selected.
        OpenProject()
        'RestoreFormSettings()
        'Project.ReadProjectInfoFile()

        'Project.ReadParameters()
        'Project.ReadParentParameters()
        'If Project.ParentParameterExists("ProNetName") Then
        '    Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
        '    ProNetName = Project.Parameter("ProNetName").Value
        'Else
        '    ProNetName = Project.GetParameter("ProNetName")
        'End If
        'If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
        '    Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
        '    ProNetPath = Project.Parameter("ProNetPath").Value
        'Else
        '    ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
        'End If
        'Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

        'Project.LockProject() 'Lock the project while it is open in this application.

        'Project.Usage.StartTime = Now

        'ApplicationInfo.SettingsLocn = Project.SettingsLocn
        'Message.SettingsLocn = Project.SettingsLocn
        'Message.Show() 'Added 18May19

        ''Restore the new project settings:
        'RestoreProjectSettings() 'Update this subroutine if project settings need to be restored.

        'ShowProjectInfo()

        '''Show the project information:
        ''txtProjectName.Text = Project.Name
        ''txtProjectDescription.Text = Project.Description
        ''Select Case Project.Type
        ''    Case ADVL_Utilities_Library_1.Project.Types.Directory
        ''        txtProjectType.Text = "Directory"
        ''    Case ADVL_Utilities_Library_1.Project.Types.Archive
        ''        txtProjectType.Text = "Archive"
        ''    Case ADVL_Utilities_Library_1.Project.Types.Hybrid
        ''        txtProjectType.Text = "Hybrid"
        ''    Case ADVL_Utilities_Library_1.Project.Types.None
        ''        txtProjectType.Text = "None"
        ''End Select

        ''txtCreationDate.Text = Format(Project.CreationDate, "d-MMM-yyyy H:mm:ss")
        ''txtLastUsed.Text = Format(Project.Usage.LastUsed, "d-MMM-yyyy H:mm:ss")
        ''Select Case Project.SettingsLocn.Type
        ''    Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ''        txtSettingsLocationType.Text = "Directory"
        ''    Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
        ''        txtSettingsLocationType.Text = "Archive"
        ''End Select
        ''txtSettingsPath.Text = Project.SettingsLocn.Path
        ''Select Case Project.DataLocn.Type
        ''    Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
        ''        txtDataLocationType.Text = "Directory"
        ''    Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
        ''        txtDataLocationType.Text = "Archive"
        ''End Select
        ''txtDataPath.Text = Project.DataLocn.Path

        'If Project.ConnectOnOpen Then
        '    ConnectToComNet() 'The Project is set to connect when it is opened.
        'ElseIf ApplicationInfo.ConnectOnStartup Then
        '    ConnectToComNet() 'The Application is set to connect when it is started.
        'Else
        '    'Don't connect to ComNet.
        'End If

    End Sub

    Private Sub OpenProject()
        'Open the Project:
        RestoreFormSettings()
        Project.ReadProjectInfoFile()

        Project.ReadParameters()
        Project.ReadParentParameters()
        If Project.ParentParameterExists("ProNetName") Then
            Project.AddParameter("ProNetName", Project.ParentParameter("ProNetName").Value, Project.ParentParameter("ProNetName").Description) 'AddParameter will update the parameter if it already exists.
            ProNetName = Project.Parameter("ProNetName").Value
        Else
            ProNetName = Project.GetParameter("ProNetName")
        End If
        If Project.ParentParameterExists("ProNetPath") Then 'Get the parent parameter value - it may have been updated.
            Project.AddParameter("ProNetPath", Project.ParentParameter("ProNetPath").Value, Project.ParentParameter("ProNetPath").Description) 'AddParameter will update the parameter if it already exists.
            ProNetPath = Project.Parameter("ProNetPath").Value
        Else
            ProNetPath = Project.GetParameter("ProNetPath") 'If the parameter does not exist, the value is set to ""
        End If
        Project.SaveParameters() 'These should be saved now - child projects look for parent parameters in the parameter file.

        Project.LockProject() 'Lock the project while it is open in this application.

        Project.Usage.StartTime = Now

        ApplicationInfo.SettingsLocn = Project.SettingsLocn
        Message.SettingsLocn = Project.SettingsLocn
        Message.Show() 'Added 18May19

        'Restore the new project settings:
        RestoreProjectSettings() 'Update this subroutine if project settings need to be restored.

        ShowProjectInfo()

        If Project.ConnectOnOpen Then
            ConnectToComNet() 'The Project is set to connect when it is opened.
        ElseIf ApplicationInfo.ConnectOnStartup Then
            ConnectToComNet() 'The Application is set to connect when it is started.
        Else
            'Don't connect to ComNet.
        End If
    End Sub

#Region " Online/Offline code"

    Private Sub btnOnline_Click(sender As Object, e As EventArgs) Handles btnOnline.Click
        'Connect to or disconnect from the Application Network.
        If ConnectedToComNet = False Then
            ConnectToComNet()
        Else
            DisconnectFromComNet()
        End If
    End Sub

    Private Sub ConnectToComNet()
        'Connect to the Message Service. (ComNet)

        If IsNothing(client) Then
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        'UPDATE 14 Feb 2021 - If the VS2019 version of the ADVL Network is running it may not detected by ComNetRunning()!
        'Check if the Message Service is running by trying to open a connection:
        Try
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds (8 seconds is too short for a slow computer!)
            ConnectionName = ApplicationInfo.Name 'This name will be modified if it is already used in an existing connection.
            ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)
            If ConnectionName <> "" Then
                Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
                btnOnline.Text = "Online"
                btnOnline.ForeColor = Color.ForestGreen
                ConnectedToComNet = True
                SendApplicationInfo()
                SendProjectInfo()
                client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                bgwComCheck.WorkerReportsProgress = True
                bgwComCheck.WorkerSupportsCancellation = True
                If bgwComCheck.IsBusy Then
                    'The ComCheck thread is already running.
                Else
                    bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                End If
                Exit Sub 'Connection made OK
            Else
                'Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                Message.Add("The Andorville™ Network was not found. Attempting to start it." & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            End If
        Catch ex As System.TimeoutException
            Message.Add("Message Service Check Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            Message.Add("Attempting to start the Message Service." & vbCrLf)
        Catch ex As Exception
            Message.Add("Error message: " & ex.Message & vbCrLf)
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            Message.Add("Attempting to start the Message Service." & vbCrLf)
        End Try

        If ComNetRunning() Then
            'The Application.Lock file has been found at AdvlNetworkAppPath
            'The Message Service is Running.
        Else 'The Message Service is NOT running'
            'Start the Andorville™ Network:
            If AdvlNetworkAppPath = "" Then
                Message.AddWarning("Andorville™ Network application path is unknown." & vbCrLf)
            Else
                If System.IO.File.Exists(AdvlNetworkExePath) Then 'OK to start the Message Service application:
                    Shell(Chr(34) & AdvlNetworkExePath & Chr(34), AppWinStyle.NormalFocus) 'Start Message Service application with no argument
                Else
                    'Incorrect Message Service Executable path.
                    Message.AddWarning("Andorville™ Network exe file not found. Service not started." & vbCrLf)
                End If
            End If
        End If

        'Try to fix a faulted client state:
        If client.State = ServiceModel.CommunicationState.Faulted Then
            client = Nothing
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        If client.State = ServiceModel.CommunicationState.Faulted Then
            Message.AddWarning("Client state is faulted. Connection not made!" & vbCrLf)
        Else
            Try
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds (8 seconds is too short for a slow computer!)

                ConnectionName = ApplicationInfo.Name 'This name will be modified if it is already used in an existing connection.
                ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)

                If ConnectionName <> "" Then
                    Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                    btnOnline.Text = "Online"
                    btnOnline.ForeColor = Color.ForestGreen
                    ConnectedToComNet = True
                    SendApplicationInfo()
                    SendProjectInfo()
                    client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                    bgwComCheck.WorkerReportsProgress = True
                    bgwComCheck.WorkerSupportsCancellation = True
                    If bgwComCheck.IsBusy Then
                        'The ComCheck thread is already running.
                    Else
                        bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                    End If

                Else
                    Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                End If
            Catch ex As System.TimeoutException
                Message.Add("Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
            Catch ex As Exception
                Message.Add("Error message: " & ex.Message & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
            End Try
        End If
    End Sub

    Private Sub ConnectToComNet(ByVal ConnName As String)
        'Connect to the Message Service (ComNet) with the connection name ConnName.

        'UPDATE 14 Feb 2021 - If the VS2019 version of the ADVL Network is running it may not be detected by ComNetRunning()!
        'Check if the Message Service is running by trying to open a connection:

        If IsNothing(client) Then
            client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
        End If

        Try
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds (8 seconds is too short for a slow computer!)
            ConnectionName = ConnName 'This name will be modified if it is already used in an existing connection.
            ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)
            If ConnectionName <> "" Then
                Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
                btnOnline.Text = "Online"
                btnOnline.ForeColor = Color.ForestGreen
                ConnectedToComNet = True
                SendApplicationInfo()
                SendProjectInfo()
                client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                bgwComCheck.WorkerReportsProgress = True
                bgwComCheck.WorkerSupportsCancellation = True
                If bgwComCheck.IsBusy Then
                    'The ComCheck thread is already running.
                Else
                    bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                End If
                Exit Sub 'Connection made OK
            Else
                'Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                Message.Add("The Andorville™ Network was not found. Attempting to start it." & vbCrLf)
                client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            End If
        Catch ex As System.TimeoutException
            Message.Add("Message Service Check Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            Message.Add("Attempting to start the Message Service." & vbCrLf)
        Catch ex As Exception
            Message.Add("Error message: " & ex.Message & vbCrLf)
            client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeout to 1 hour
            Message.Add("Attempting to start the Message Service." & vbCrLf)
        End Try


        If ConnectedToComNet = False Then
            Dim Result As Boolean

            If IsNothing(client) Then
                client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
            End If

            'Try to fix a faulted client state:
            If client.State = ServiceModel.CommunicationState.Faulted Then
                client = Nothing
                client = New ServiceReference1.MsgServiceClient(New System.ServiceModel.InstanceContext(New MsgServiceCallback))
            End If

            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.SetWarningStyle()
                Message.Add("client state is faulted. Connection not made!" & vbCrLf)
            Else
                Try
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(0, 0, 16) 'Temporarily set the send timeaout to 16 seconds
                    ConnectionName = ConnName 'This name will be modified if it is already used in an existing connection.
                    ConnectionName = client.Connect(ProNetName, ApplicationInfo.Name, ConnectionName, Project.Name, Project.Description, Project.Type, Project.Path, False, False)

                    If ConnectionName <> "" Then
                        Message.Add("Connected to the Andorville™ Network with Connection Name: [" & ProNetName & "]." & ConnectionName & vbCrLf)
                        client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                        btnOnline.Text = "Online"
                        btnOnline.ForeColor = Color.ForestGreen
                        ConnectedToComNet = True
                        SendApplicationInfo()
                        SendProjectInfo()
                        client.GetAdvlNetworkAppInfoAsync() 'Update the Exe Path in case it has changed. This path may be needed in the future to start the ComNet (Message Service).

                        bgwComCheck.WorkerReportsProgress = True
                        bgwComCheck.WorkerSupportsCancellation = True
                        If bgwComCheck.IsBusy Then
                            'The ComCheck thread is already running.
                        Else
                            bgwComCheck.RunWorkerAsync() 'Start the ComCheck thread.
                        End If

                    Else
                        Message.Add("Connection to the Andorville™ Network failed!" & vbCrLf)
                        client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                    End If
                Catch ex As System.TimeoutException
                    Message.Add("Timeout error. Check if the Andorville™ Network (Message Service) is running." & vbCrLf)
                Catch ex As Exception
                    Message.Add("Error message: " & ex.Message & vbCrLf)
                    client.Endpoint.Binding.SendTimeout = New System.TimeSpan(1, 0, 0) 'Restore the send timeaout to 1 hour
                End Try
            End If
        Else
            Message.AddWarning("Already connected to the Andorville™ Network (Message Service)." & vbCrLf)
        End If
    End Sub


    Private Sub DisconnectFromComNet()
        'Disconnect from the Communication Network (Message Service).

        If ConnectedToComNet = True Then
            If IsNothing(client) Then
                'Message.Add("Already disconnected from the Communication Network." & vbCrLf)
                Message.Add("Already disconnected from the Andorville™ Network (Message Service)." & vbCrLf)
                btnOnline.Text = "Offline"
                btnOnline.ForeColor = Color.Red
                ConnectedToComNet = False
                ConnectionName = ""
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("client state is faulted." & vbCrLf)
                    ConnectionName = ""
                Else
                    Try
                        'Message.Add("Running client.Disconnect(ApplicationName)   ApplicationName = " & ApplicationInfo.Name & vbCrLf)
                        'client.Disconnect(ApplicationInfo.Name) 'NOTE: If Application Network has closed, this application freezes at this line! Try Catch EndTry added to fix this.
                        'client.Disconnect(AppNetName, ConnectionName) 'UPDATED 2Feb19
                        client.Disconnect(ProNetName, ConnectionName)
                        btnOnline.Text = "Offline"
                        btnOnline.ForeColor = Color.Red
                        ConnectedToComNet = False
                        ConnectionName = ""
                        'Message.Add("Disconnected from the Communication Network." & vbCrLf)
                        Message.Add("Disconnected from the Andorville™ Network (Message Service)." & vbCrLf)

                        If bgwComCheck.IsBusy Then
                            bgwComCheck.CancelAsync()
                        End If

                    Catch ex As Exception
                        'Message.AddWarning("Error disconnecting from Communication Network: " & ex.Message & vbCrLf)
                        Message.AddWarning("Error disconnecting from Andorville™ Network (Message Service): " & ex.Message & vbCrLf)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub SendApplicationInfo()
        'Send the application information to the Administrator connections.

        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Message not sent!" & vbCrLf)
            Else
                'Create the XML instructions to send application information.
                Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                Dim applicationInfo As New XElement("ApplicationInfo")
                Dim name As New XElement("Name", Me.ApplicationInfo.Name)
                applicationInfo.Add(name)

                Dim text As New XElement("Text", "Well Deviation")
                applicationInfo.Add(text)

                Dim exePath As New XElement("ExecutablePath", Me.ApplicationInfo.ExecutablePath)
                applicationInfo.Add(exePath)

                Dim directory As New XElement("Directory", Me.ApplicationInfo.ApplicationDir)
                applicationInfo.Add(directory)
                Dim description As New XElement("Description", Me.ApplicationInfo.Description)
                applicationInfo.Add(description)
                xmessage.Add(applicationInfo)
                doc.Add(xmessage)

                'Show the message sent to AppNet:
                Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                Message.XAddXml(doc.ToString)
                Message.XAddText(vbCrLf, "Normal") 'Add extra line

                client.SendMessage("", "MessageService", doc.ToString) 'UPDATED 2Feb19
            End If
        End If
    End Sub

    Private Sub SendProjectInfo()
        'Send the project information to the Network application.

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    Dim Path As New XElement("Path", Project.Path)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to the Message Service:
                    Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    client.SendMessage("", "MessageService", doc.ToString)
                End If
            End If
        End If
    End Sub

    Public Sub SendProjectInfo(ByVal ProjectPath As String)
        'Send the project information to the Network application.
        'This version of SendProjectInfo uses the ProjectPath argument.

        If ConnectedToComNet = False Then
            Message.AddWarning("The application is not connected to the Message Service." & vbCrLf)
        Else 'Connected to the Message Service (ComNet).
            If IsNothing(client) Then
                Message.Add("No client connection available!" & vbCrLf)
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    Message.Add("Client state is faulted. Message not sent!" & vbCrLf)
                Else
                    'Construct the XMessage to send to AppNet:
                    Dim decl As New XDeclaration("1.0", "utf-8", "yes")
                    Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
                    Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class
                    Dim projectInfo As New XElement("ProjectInfo")

                    Dim Path As New XElement("Path", ProjectPath)
                    projectInfo.Add(Path)
                    xmessage.Add(projectInfo)
                    doc.Add(xmessage)

                    'Show the message sent to the Message Service:
                    Message.XAddText("Message sent to " & "Message Service" & ":" & vbCrLf, "XmlSentNotice")
                    Message.XAddXml(doc.ToString)
                    Message.XAddText(vbCrLf, "Normal") 'Add extra line
                    client.SendMessage("", "MessageService", doc.ToString)
                End If
            End If
        End If
    End Sub
    Private Function ComNetRunning() As Boolean
        'Return True if ComNet (Message Service) is running.
        'If System.IO.File.Exists(MsgServiceAppPath & "\Application.Lock") Then
        '    Return True
        'Else
        '    Return False
        'End If

        If AdvlNetworkAppPath = "" Then
            Message.Add("Andorville™ Network application path is not known." & vbCrLf)
            Message.Add("Run the MAndorville™ Network before connecting to update the path." & vbCrLf)
            Return False
        Else
            If System.IO.File.Exists(AdvlNetworkAppPath & "\Application.Lock") Then
                Return True
            Else
                Return False
            End If
        End If
    End Function


#End Region 'Online/Offline code

#Region " Process XMessages"

    Private Sub XMsg_Instruction(Data As String, Locn As String) Handles XMsg.Instruction
        'Process an XMessage instruction.
        'An XMessage is a simplified XSequence. It is used to exchange information between Andorville (TM) applications.
        '
        'An XSequence file is an AL-H7 (TM) Information Sequence stored in an XML format.
        'AL-H7(TM) is the name of a programming system that uses sequences of data and location value pairs to store information or processing steps.
        'Any program, mathematical expression or data set can be expressed as an Information Sequence.

        'Add code here to process the XMessage instructions.
        'See other Andorville(TM) applications for examples.

        If IsDBNull(Data) Then
            Data = ""
        End If

        'Intercept instructions with the prefix "WebPage_"
        If Locn.StartsWith("WebPage_") Then 'Send the Data, Location data to the correct Web Page:
            'Message.Add("Web Page Location: " & Locn & vbCrLf)
            If Locn.Contains(":") Then
                Dim EndOfWebPageNoString As Integer = Locn.IndexOf(":")
                If Locn.Contains("-") Then
                    Dim HyphenLocn As Integer = Locn.IndexOf("-")
                    If HyphenLocn < EndOfWebPageNoString Then 'Web Page Location contains a sub-location in the web page - WebPage_1-SubLocn:Locn - SubLocn:Locn will be sent to Web page 1
                        EndOfWebPageNoString = HyphenLocn
                    End If
                End If
                Dim PageNoLen As Integer = EndOfWebPageNoString - 8
                Dim WebPageNoString As String = Locn.Substring(8, PageNoLen)
                Dim WebPageNo As Integer = CInt(WebPageNoString)
                Dim WebPageData As String = Data
                Dim WebPageLocn As String = Locn.Substring(EndOfWebPageNoString + 1)

                'Message.Add("WebPageData = " & WebPageData & "  WebPageLocn = " & WebPageLocn & vbCrLf)

                WebPageFormList(WebPageNo).XMsgInstruction(WebPageData, WebPageLocn)
            Else
                Message.AddWarning("XMessage instruction location is not complete: " & Locn & vbCrLf)
            End If
        Else

            Select Case Locn

            'Case "ClientAppNetName"
            '    ClientAppNetName = Data 'The name of the Client Application Network requesting service. ADDED 2Feb19.
                Case "ClientProNetName"
                    ClientProNetName = Data 'The name of the Client Project Network requesting service.

                Case "ClientName"
                    ClientAppName = Data 'The name of the Client requesting service.

                Case "ClientConnectionName"
                    ClientConnName = Data 'The name of the client requesting service.

                Case "ClientLocn" 'The Location within the Client requesting service.
                    Dim statusOK As New XElement("Status", "OK") 'Add Status OK element when the Client Location is changed
                    xlocns(xlocns.Count - 1).Add(statusOK)

                    xmessage.Add(xlocns(xlocns.Count - 1)) 'Add the instructions for the last location to the reply xmessage
                    xlocns.Add(New XElement(Data)) 'Start the new location instructions

                'Case "OnCompletion" 'Specify the last instruction to be returned on completion of the XMessage processing.
                '    CompletionInstruction = Data

                  'UPDATE:
                Case "OnCompletion"
                    OnCompletionInstruction = Data

                Case "Main"
                'No instructions - do nothing

                'Case "Main:OnCompletion"
                '    Select Case "Stop"
                '        'Stop on completion of the instruction sequence.
                '    End Select

                Case "Main:EndInstruction"
                    Select Case Data
                        Case "Stop"
                            'Stop at the end of the instruction sequence.

                            'Add other cases here:
                    End Select

                Case "Main:Status"
                    Select Case Data
                        Case "OK"
                            'Main instructions completed OK
                    End Select

                Case "Command"
                    Select Case Data
                    'Case "ConnectToAppNet" 'Startup Command
                        Case "ConnectToComNet" 'Startup Command
                            'If ConnectedToAppnet = False Then
                            If ConnectedToComNet = False Then
                                'ConnectToAppNet()
                                ConnectToComNet()
                            End If

                        Case "AppComCheck"
                            'Add the Appplication Communication info to the reply message:
                            Dim clientProNetName As New XElement("ClientProNetName", ProNetName) 'The Project Network Name
                            xlocns(xlocns.Count - 1).Add(clientProNetName)
                            Dim clientName As New XElement("ClientName", "ADVL_Well_Deviation_1") 'The name of this application.
                            xlocns(xlocns.Count - 1).Add(clientName)
                            Dim clientConnectionName As New XElement("ClientConnectionName", ConnectionName)
                            xlocns(xlocns.Count - 1).Add(clientConnectionName)
                            '<Status>OK</Status> will be automatically appended to the XMessage before it is sent.

                    End Select




            'Case "ConvertedAngle:NorthLatDmsSign"
            '    Select Case Data
            '        Case "-"
            '            GetCRSListForm.cmbNLatNS.SelectedIndex = GetCRSListForm.cmbNLatNS.FindStringExact("S")
            '        Case "+"
            '            GetCRSListForm.cmbNLatNS.SelectedIndex = GetCRSListForm.cmbNLatNS.FindStringExact("N")
            '        Case ""
            '            GetCRSListForm.cmbNLatNS.SelectedIndex = GetCRSListForm.cmbNLatNS.FindStringExact("N")
            '        Case Else
            '            Message.SetWarningStyle()
            '            Message.Add("North Latitide DMS Sign unknown: " & Data & vbCrLf)
            '            Message.SetNormalStyle()
            '    End Select
            'Case "ConvertedAngle:NorthLatDmsDegrees"
            '    GetCRSListForm.txtNLatDegrees.Text = Data
            'Case "ConvertedAngle:NorthLatDmsMinutes"
            '    GetCRSListForm.txtNLatMinutes.Text = Data
            'Case "ConvertedAngle:NorthLatDmsSeconds"
            '    GetCRSListForm.txtNLatSeconds.Text = Data

                Case "GetCRSList_NorthLat:ConvertedAngle:DmsSign"
                    Select Case Data
                        Case "-"
                            GetCRSListForm.cmbNLatNS.SelectedIndex = GetCRSListForm.cmbNLatNS.FindStringExact("S")
                        Case "+"
                            GetCRSListForm.cmbNLatNS.SelectedIndex = GetCRSListForm.cmbNLatNS.FindStringExact("N")
                        Case ""
                            GetCRSListForm.cmbNLatNS.SelectedIndex = GetCRSListForm.cmbNLatNS.FindStringExact("N")
                        Case Else
                            Message.SetWarningStyle()
                            Message.Add("North Latitide DMS Sign unknown: " & Data & vbCrLf)
                            Message.SetNormalStyle()
                    End Select
                Case "GetCRSList_NorthLat:ConvertedAngle:DmsDegrees"
                    GetCRSListForm.txtNLatDegrees.Text = Data
                Case "GetCRSList_NorthLat:ConvertedAngle:DmsMinutes"
                    GetCRSListForm.txtNLatMinutes.Text = Data
                Case "GetCRSList_NorthLat:ConvertedAngle:DmsSeconds"
                    GetCRSListForm.txtNLatSeconds.Text = Data

            'Case "ConvertedAngle:SouthLatDmsSign"
            '    Select Case Data
            '        Case "-"
            '            GetCRSListForm.cmbSLatNS.SelectedIndex = GetCRSListForm.cmbSLatNS.FindStringExact("S")
            '        Case "+"
            '            GetCRSListForm.cmbSLatNS.SelectedIndex = GetCRSListForm.cmbSLatNS.FindStringExact("N")
            '        Case ""
            '            GetCRSListForm.cmbSLatNS.SelectedIndex = GetCRSListForm.cmbSLatNS.FindStringExact("N")
            '        Case Else
            '            Message.SetWarningStyle()
            '            Message.Add("South Latitide DMS Sign unknown: " & Data & vbCrLf)
            '            Message.SetNormalStyle()
            '    End Select
            'Case "ConvertedAngle:SouthLatDmsDegrees"
            '    GetCRSListForm.txtSLatDegrees.Text = Data
            'Case "ConvertedAngle:SouthLatDmsMinutes"
            '    GetCRSListForm.txtSLatMinutes.Text = Data
            'Case "ConvertedAngle:SouthLatDmsSeconds"
            '    GetCRSListForm.txtSLatSeconds.Text = Data

                Case "GetCRSList_SouthLat:ConvertedAngle:DmsSign"
                    Select Case Data
                        Case "-"
                            GetCRSListForm.cmbSLatNS.SelectedIndex = GetCRSListForm.cmbSLatNS.FindStringExact("S")
                        Case "+"
                            GetCRSListForm.cmbSLatNS.SelectedIndex = GetCRSListForm.cmbSLatNS.FindStringExact("N")
                        Case ""
                            GetCRSListForm.cmbSLatNS.SelectedIndex = GetCRSListForm.cmbSLatNS.FindStringExact("N")
                        Case Else
                            Message.SetWarningStyle()
                            Message.Add("South Latitide DMS Sign unknown: " & Data & vbCrLf)
                            Message.SetNormalStyle()
                    End Select
                Case "GetCRSList_SouthLat:ConvertedAngle:DmsDegrees"
                    GetCRSListForm.txtSLatDegrees.Text = Data
                Case "GetCRSList_SouthLat:ConvertedAngle:DmsMinutes"
                    GetCRSListForm.txtSLatMinutes.Text = Data
                Case "GetCRSList_SouthLat:ConvertedAngle:DmsSeconds"
                    GetCRSListForm.txtSLatSeconds.Text = Data

            'Case "ConvertedAngle:WestLongDmsSign"
            '    Select Case Data
            '        Case "-"
            '            GetCRSListForm.cmbWLongWE.SelectedIndex = GetCRSListForm.cmbWLongWE.FindStringExact("W")
            '        Case "+"
            '            GetCRSListForm.cmbWLongWE.SelectedIndex = GetCRSListForm.cmbWLongWE.FindStringExact("E")
            '        Case ""
            '            GetCRSListForm.cmbWLongWE.SelectedIndex = GetCRSListForm.cmbWLongWE.FindStringExact("E")
            '        Case Else
            '            Message.SetWarningStyle()
            '            Message.Add("West Longitide DMS Sign unknown: " & Data & vbCrLf)
            '            Message.SetNormalStyle()
            '    End Select
            'Case "ConvertedAngle:WestLongDmsDegrees"
            '    GetCRSListForm.txtWLongDegrees.Text = Data
            'Case "ConvertedAngle:WestLongDmsMinutes"
            '    GetCRSListForm.txtWLongMinutes.Text = Data
            'Case "ConvertedAngle:WestLongDmsSeconds"
            '    GetCRSListForm.txtWLongSeconds.Text = Data

                Case "GetCRSList_WestLong:ConvertedAngle:DmsSign"
                    Select Case Data
                        Case "-"
                            GetCRSListForm.cmbWLongWE.SelectedIndex = GetCRSListForm.cmbWLongWE.FindStringExact("W")
                        Case "+"
                            GetCRSListForm.cmbWLongWE.SelectedIndex = GetCRSListForm.cmbWLongWE.FindStringExact("E")
                        Case ""
                            GetCRSListForm.cmbWLongWE.SelectedIndex = GetCRSListForm.cmbWLongWE.FindStringExact("E")
                        Case Else
                            Message.SetWarningStyle()
                            Message.Add("West Longitide DMS Sign unknown: " & Data & vbCrLf)
                            Message.SetNormalStyle()
                    End Select
                Case "GetCRSList_WestLong:ConvertedAngle:DmsDegrees"
                    GetCRSListForm.txtWLongDegrees.Text = Data
                Case "GetCRSList_WestLong:ConvertedAngle:DmsMinutes"
                    GetCRSListForm.txtWLongMinutes.Text = Data
                Case "GetCRSList_WestLong:ConvertedAngle:DmsSeconds"
                    GetCRSListForm.txtWLongSeconds.Text = Data

            'Case "ConvertedAngle:EastLongDmsSign"
            '    Select Case Data
            '        Case "-"
            '            GetCRSListForm.cmbELongWE.SelectedIndex = GetCRSListForm.cmbELongWE.FindStringExact("W")
            '        Case "+"
            '            GetCRSListForm.cmbELongWE.SelectedIndex = GetCRSListForm.cmbELongWE.FindStringExact("E")
            '        Case ""
            '            GetCRSListForm.cmbELongWE.SelectedIndex = GetCRSListForm.cmbELongWE.FindStringExact("E")
            '        Case Else
            '            Message.SetWarningStyle()
            '            Message.Add("East Longitide DMS Sign unknown: " & Data & vbCrLf)
            '            Message.SetNormalStyle()
            '    End Select
            'Case "ConvertedAngle:EastLongDmsDegrees"
            '    GetCRSListForm.txtELongDegrees.Text = Data
            'Case "ConvertedAngle:EastLongDmsMinutes"
            '    GetCRSListForm.txtELongMinutes.Text = Data
            'Case "ConvertedAngle:EastLongDmsSeconds"
            '    GetCRSListForm.txtELongSeconds.Text = Data

                Case "GetCRSList_EastLong:ConvertedAngle:DmsSign"
                    Select Case Data
                        Case "-"
                            GetCRSListForm.cmbELongWE.SelectedIndex = GetCRSListForm.cmbELongWE.FindStringExact("W")
                        Case "+"
                            GetCRSListForm.cmbELongWE.SelectedIndex = GetCRSListForm.cmbELongWE.FindStringExact("E")
                        Case ""
                            GetCRSListForm.cmbELongWE.SelectedIndex = GetCRSListForm.cmbELongWE.FindStringExact("E")
                        Case Else
                            Message.SetWarningStyle()
                            Message.Add("East Longitide DMS Sign unknown: " & Data & vbCrLf)
                            Message.SetNormalStyle()
                    End Select
                Case "GetCRSList_EastLong:ConvertedAngle:DmsDegrees"
                    GetCRSListForm.txtELongDegrees.Text = Data
                Case "GetCRSList_EastLong:ConvertedAngle:DmsMinutes"
                    GetCRSListForm.txtELongMinutes.Text = Data
                Case "GetCRSList_EastLong:ConvertedAngle:DmsSeconds"
                    GetCRSListForm.txtELongSeconds.Text = Data

            'Case "Geographic2DCrsList:Geographic2DCrsName"
                Case "Main:Geographic2DCrsList:Geographic2DCrsName"
                    cmbGeoCRS.Items.Add(Data)

            'Case "Geographic3DCrsList:Geographic3DCrsName"
                Case "Main:Geographic3DCrsList:Geographic3DCrsName"
                    cmbGeoCRS.Items.Add(Data)

            'Case "ProjectedCrsList:ProjectedCrsName"
                Case "Main:ProjectedCrsList:ProjectedCrsName"
                    cmbProjCRS.Items.Add(Data)

            'Case "TransformedCoordinates:OutputEasting"
                Case "Main:TransformedCoordinates:OutputEasting"
                    txtEasting.Text = Data

            'Case "TransformedCoordinates:OutputNorthing"
                Case "Main:TransformedCoordinates:OutputNorthing"
                    txtNorthing.Text = Data


            'Startup Command Arguments ================================================
                Case "ProjectName"
                    If Project.OpenProject(Data) = True Then
                        ProjectSelected = True 'Project has been opened OK.
                    Else
                        ProjectSelected = False 'Project could not be opened.
                    End If

                Case "ProjectID"
                    Message.AddWarning("Add code to handle ProjectID parameter at StartUp!" & vbCrLf)
                'Note the AppNet will usually select a project using ProjectPath.

                'Case "ProjectPath"
                '    If Project.OpenProjectPath(Data) = True Then
                '        ProjectSelected = True 'Project has been opened OK.
                '    Else
                '        ProjectSelected = False 'Project could not be opened.
                '    End If

                Case "ProjectPath"
                    If Project.OpenProjectPath(Data) = True Then
                        ProjectSelected = True 'Project has been opened OK.
                        'THE PROJECT IS LOCKED IN THE Form.Load EVENT:

                        ApplicationInfo.SettingsLocn = Project.SettingsLocn
                        Message.SettingsLocn = Project.SettingsLocn 'Set up the Message object
                        Message.Show() 'Added 18May19

                        'txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                        '              Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                        '              Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                        '              Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c)

                        'txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & ":" &
                        '               Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & ":" &
                        '               Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                        '               Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c)

                        txtTotalDuration.Text = Project.Usage.TotalDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                                        Project.Usage.TotalDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                                        Project.Usage.TotalDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                                        Project.Usage.TotalDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"

                        txtCurrentDuration.Text = Project.Usage.CurrentDuration.Days.ToString.PadLeft(5, "0"c) & "d:" &
                                       Project.Usage.CurrentDuration.Hours.ToString.PadLeft(2, "0"c) & "h:" &
                                       Project.Usage.CurrentDuration.Minutes.ToString.PadLeft(2, "0"c) & "m:" &
                                       Project.Usage.CurrentDuration.Seconds.ToString.PadLeft(2, "0"c) & "s"

                    Else
                        ProjectSelected = False 'Project could not be opened.
                        Message.AddWarning("Project could not be opened at path: " & Data & vbCrLf)
                    End If



                Case "ConnectionName"
                    StartupConnectionName = Data
            '--------------------------------------------------------------------------


            'Application Information  =================================================
            'returned by client.GetAdvlNetworkAppInfoAsync()
            'Case "MessageServiceAppInfo:Name"
            '    'The name of the Message Service Application. (Not used.)
                Case "AdvlNetworkAppInfo:Name"
                'The name of the Andorville™ Network Application. (Not used.)

            'Case "MessageServiceAppInfo:ExePath"
            '    'The executable file path of the Message Service Application.
            '    MsgServiceExePath = Data
                Case "AdvlNetworkAppInfo:ExePath"
                    'The executable file path of the Andorville™ Network Application.
                    AdvlNetworkExePath = Data

            'Case "MessageServiceAppInfo:Path"
            '    'The path of the Message Service Application (ComNet). (This is where an Application.Lock file will be found while ComNet is running.)
            '    MsgServiceAppPath = Data
                Case "AdvlNetworkAppInfo:Path"
                    'The path of the Andorville™ Network Application (ComNet). (This is where an Application.Lock file will be found while ComNet is running.)
                    AdvlNetworkAppPath = Data

           '---------------------------------------------------------------------------

               'Message Window Instructions  ==============================================
                Case "MessageWindow:Left"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Left = Data
                Case "MessageWindow:Top"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Top = Data
                Case "MessageWindow:Width"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Width = Data
                Case "MessageWindow:Height"
                    If IsNothing(Message.MessageForm) Then
                        Message.ApplicationName = ApplicationInfo.Name
                        Message.SettingsLocn = Project.SettingsLocn
                        Message.Show()
                    End If
                    Message.MessageForm.Height = Data
                Case "MessageWindow:Command"
                    Select Case Data
                        Case "BringToFront"
                            If IsNothing(Message.MessageForm) Then
                                Message.ApplicationName = ApplicationInfo.Name
                                Message.SettingsLocn = Project.SettingsLocn
                                Message.Show()
                            End If
                            'Message.MessageForm.BringToFront()
                            Message.MessageForm.Activate()
                            Message.MessageForm.TopMost = True
                            Message.MessageForm.TopMost = False
                        Case "SaveSettings"
                            Message.MessageForm.SaveFormSettings()
                    End Select

            '---------------------------------------------------------------------------

                        'Command to bring the Application window to the front:
                Case "ApplicationWindow:Command"
                    Select Case Data
                        Case "BringToFront"
                            Me.Activate()
                            Me.TopMost = True
                            Me.TopMost = False
                    End Select


                Case "EndOfSequence"
                    'End of Information Vector Sequence reached.
                    'Add Status OK element at the end of the sequence:
                    Dim statusOK As New XElement("Status", "OK")
                    xlocns(xlocns.Count - 1).Add(statusOK)

                    Select Case EndInstruction
                        Case "Stop"
                            'No instructions.

                            'Add any other Cases here:

                        Case Else
                            Message.AddWarning("Unknown End Instruction: " & EndInstruction & vbCrLf)
                    End Select
                    EndInstruction = "Stop"

                    ''Add the final OnCompletion instruction:
                    'Dim onCompletion As New XElement("OnCompletion", CompletionInstruction) '
                    'xlocns(xlocns.Count - 1).Add(onCompletion)
                    'CompletionInstruction = "Stop" 'Reset the Completion Instruction

                    ''Final Version:
                    ''Add the final EndInstruction:
                    'Dim xEndInstruction As New XElement("EndInstruction", OnCompletionInstruction)
                    'xlocns(xlocns.Count - 1).Add(xEndInstruction)
                    'OnCompletionInstruction = "Stop" 'Reset the OnCompletion Instruction

                    'Add the final EndInstruction:
                    If OnCompletionInstruction = "Stop" Then
                        'Final EndInstruction is not required.
                    Else
                        Dim xEndInstruction As New XElement("EndInstruction", OnCompletionInstruction)
                        xlocns(xlocns.Count - 1).Add(xEndInstruction)
                        OnCompletionInstruction = "Stop" 'Reset the OnCompletion Instruction
                    End If

                Case Else
                    'Message.SetWarningStyle()
                    'Message.Add("Unknown location: " & Locn & vbCrLf)
                    'Message.SetNormalStyle()
                    Message.AddWarning("Unknown location: " & Locn & vbCrLf)
                    Message.AddWarning("            data: " & Data & vbCrLf)
            End Select
        End If
    End Sub

    'Private Sub SendMessage()
    '    'Code used to send a message after a timer delay.
    '    'The message destination is stored in MessageDest
    '    'The message text is stored in MessageText
    '    Timer1.Interval = 100 '100ms delay
    '    Timer1.Enabled = True 'Start the timer.
    'End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    '    If IsNothing(client) Then
    '        Message.SetWarningStyle()
    '        Message.Add("No client connection available!" & vbCrLf)
    '    Else
    '        If client.State = ServiceModel.CommunicationState.Faulted Then
    '            Message.SetWarningStyle()
    '            Message.Add("client state is faulted. Message not sent!" & vbCrLf)
    '        Else
    '            Try
    '                'Message.Add("Sending a message. Number of characters: " & MessageText.Length & vbCrLf)
    '                'client.SendMessage(MessageDest, MessageText)
    '                'client.SendMessage(ClientConnName, MessageText)
    '                'client.SendMessage(ClientAppNetName, ClientConnName, MessageText) 'Added 2Feb19
    '                client.SendMessage(ClientProNetName, ClientConnName, MessageText)
    '                'Message.XAdd(MessageText & vbCrLf)
    '                'MessageText = "" 'Clear the message after it has been sent.
    '                MessageText = "" 'Clear the message after it has been sent.
    '                ClientAppName = "" 'Clear the Client Application Name after the message has been sent.
    '                ClientConnName = "" 'Clear the Client Application Name after the message has been sent.
    '                xlocns.Clear()
    '            Catch ex As Exception
    '                'Message.SetWarningStyle()
    '                'Message.Add("Error sending message: " & ex.Message & vbCrLf)
    '                Message.AddWarning("Error sending message: " & ex.Message & vbCrLf)
    '            End Try
    '        End If
    '    End If

    '    'Stop timer:
    '    Timer1.Enabled = False
    'End Sub

    Private Sub btnOpenTemplateForm_Click(sender As Object, e As EventArgs) Handles btnOpenTemplateForm.Click

    End Sub



#End Region 'Process XMessages

    Private Sub SetupDistanceUnitsDictionary()
        'Set up the dictionary of distance units: 
        'The standard distance unit is metre.
        'The value in metres is input value * FactorB / FactorC

        dictDistanceUnits.Add("metre", New ConversionFactors)
        dictDistanceUnits("metre").FactorB = 1
        dictDistanceUnits("metre").FactorC = 1

        dictDistanceUnits.Add("foot", New ConversionFactors)
        dictDistanceUnits("foot").FactorB = 0.3048
        dictDistanceUnits("foot").FactorC = 1

    End Sub

    Private Sub SetupAngleUnitsDictionary()
        'Set up the dictionary of angle units: 
        'The standard distance unit is radian.
        'The value in metres is input value * FactorB / FactorC

        dictAngleUnits.Add("radian", New ConversionFactors)
        dictAngleUnits("radian").FactorB = 1
        dictAngleUnits("radian").FactorC = 1

        dictAngleUnits.Add("degree", New ConversionFactors)
        dictAngleUnits("degree").FactorB = 3.14159265358979
        dictAngleUnits("degree").FactorC = 180

    End Sub

    'Private Sub CopyPasteButton_Click(ByVal sender As Object,
    'ByVal e As System.EventArgs) Handles CopyPasteButton.Click

    '    'If Me.DataGridView1.GetCellCount(
    '    If dgvMeasuredData.GetCellCount(
    '    DataGridViewElementStates.Selected) > 0 Then

    '        Try

    '            ' Add the selection to the clipboard.
    '            Clipboard.SetDataObject(
    '            dgvMeasuredData.GetClipboardContent())

    '            ' Replace the text box contents with the clipboard text.
    '            'Me.TextBox1.Text = Clipboard.GetText()

    '        Catch ex As System.Runtime.InteropServices.ExternalException
    '            'Me.TextBox1.Text =
    '            '"The Clipboard could not be accessed. Please try again."
    '        End Try

    '    End If

    'End Sub


    'Private Sub PasteFromClipboard(ByVal sender As Object, ByVal e As KeyEventArgs)
    '    Dim dgv = TryCast(sender, DataGridView)

    '    If Not IsNothing(dgv) AndAlso Clipboard.ContainsText Then
    '        If dgv.SelectedCells.Count > 0 Then
    '            Dim rowSplitter = {ControlChars.NewLine}
    '            Dim columnSplitter = {ControlChars.Tab}
    '            Dim topLeftCell = CopyPasteFunctions.GetTopLeftSelectedCell(dgv.SelectedCells)

    '            If Not IsNothing(topLeftCell) Then
    '                Dim clipBoardText = Clipboard.GetText(TextDataFormat.Text)
    '                Dim columnIndex = topLeftCell.ColumnIndex
    '                Dim rowIndex = topLeftCell.RowIndex
    '                Dim columnCount = dgv.Columns.Count
    '                Dim rows = clipBoardText.Split(rowSplitter, StringSplitOptions.None)

    '                For i = 0 To rows.Length - 2
    '                    'Split row into cell values
    '                    Dim values = rows(i).Split(columnSplitter)
    '                    Dim rowCount = dgv.Rows.Count

    '                    For j = 0 To values.Length - 1
    '                        If (i <= (rowCount - 1)) AndAlso ((j + 1) <= columnCount) Then
    '                            Dim cell = dgv.Rows(rowIndex + i).Cells(columnIndex + j)
    '                            dgv.CurrentCell = cell
    '                            dgv.BeginEdit(False)
    '                            dgv.EditingControl.Text = values(j)

    '                            If Not Me.Validate() Then
    '                                Exit Sub
    '                            Else
    '                                dgv.EndEdit()
    '                            End If
    '                        End If
    '                    Next
    '                Next
    '            End If
    '        End If
    '    End If


    'End Sub


    Sub pastefromclipboardtodatagridview(ByVal dgv As DataGridView)
        Dim rowSplitter As Char() = {vbCr, vbLf}
        Dim columnSplitter As Char() = {vbTab}

        'get the text from clipboard

        Dim dataInClipboard As IDataObject = Clipboard.GetDataObject()
        Dim stringInClipboard As String = CStr(dataInClipboard.GetData(DataFormats.Text))

        'split it into lines
        Dim rowsInClipboard As String() = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries)

        'get the row and column of selected cell in grid
        Dim r As Integer = dgv.SelectedCells(0).RowIndex
        Dim c As Integer = dgv.SelectedCells(0).ColumnIndex

        'add rows into grid to fit clipboard lines
        If (dgv.Rows.Count < (r + rowsInClipboard.Length)) Then
            dgv.Rows.Add(r + rowsInClipboard.Length - dgv.Rows.Count)
            'Add an extra row at the end.
            dgv.Rows.Add()
        End If

        ' loop through the lines, split them into cells and place the values in the corresponding cell.
        Dim iRow As Integer = 0
        While iRow < rowsInClipboard.Length
            'split row into cell values
            Dim valuesInRow As String() = rowsInClipboard(iRow).Split(columnSplitter)
            'cycle through cell values
            Dim iCol As Integer = 0
            While iCol < valuesInRow.Length
                'assign cell value, only if it within columns of the grid
                If (dgv.ColumnCount - 1 >= c + iCol) Then
                    dgv.Rows(r + iRow).Cells(c + iCol).Value = valuesInRow(iCol)
                End If
                iCol += 1
            End While
            iRow += 1
        End While

    End Sub

    'Private Sub btnPaste_Click(sender As Object, e As EventArgs)
    '    pastefromclipboardtodatagridview(dgvMeasuredData)
    'End Sub

    '  'http://stackoverflow.com/questions/1718389/right-click-context-menu-for-datagridview



    'Private Sub dgvMeasuredData_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvMeasuredData.MouseClick
    '    Debug.Print("MouseClick")
    '    If e.Button = MouseButtons.Right Then
    '        'Dim mm As ContextMenu = New ContextMenu
    '        'mm.MenuItems.Add(New MenuItem("CCut"))
    '        'mm.MenuItems.Add(New MenuItem("CCopy"))
    '        'mm.MenuItems.Add(New MenuItem("PPaste"))

    '        Dim currentMouseOverRow As Integer = dgvMeasuredData.HitTest(e.X, e.Y).RowIndex
    '        If currentMouseOverRow >= 0 Then

    '        End If

    '        'mm.Show(dgvMeasuredData, New Point(e.X, e.Y))



    '    End If
    'End Sub

    Private Sub dgvMeasuredData_ContextMenuChanged(sender As Object, e As EventArgs) Handles dgvMeasuredData.ContextMenuChanged

    End Sub

    Private Sub dgvMeasuredData_CellContextMenuStripChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMeasuredData.CellContextMenuStripChanged
        Debug.Print("CellContextMenuStripChanged " & e.ToString)
    End Sub

    Private Sub dgvMeasuredData_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvMeasuredData.CellContextMenuStripNeeded
        Debug.Print("CellContextMenuStripNeeded " & e.ToString)
    End Sub

    'Private Sub m_Popup(sender As Object, e As EventArgs) Handles m.Popup

    'End Sub

    'WellPathCalcMethod property is only updated when the calculations are performed.
    'Private Sub cmbCalcMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalcMethod.SelectedIndexChanged
    '    Select Case cmbCalcMethod.SelectedItem.ToString
    '        Case "Average Angle"
    '            _wellPathCalcMethod = WellPathCalcMethods.AverageAngle
    '        Case "Balanced Angle"
    '            _wellPathCalcMethod = WellPathCalcMethods.BalancedAngle
    '        Case "Minimum Curvature"
    '            _wellPathCalcMethod = WellPathCalcMethods.MinimumCurvature
    '        Case "Radius of Curvature"
    '            _wellPathCalcMethod = WellPathCalcMethods.RadiusOfCurvature
    '        Case "Tangential"
    '            _wellPathCalcMethod = WellPathCalcMethods.Tangential
    '    End Select
    'End Sub

    'Private Sub cms_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles cms.MouseDoubleClick


    'End Sub

    'Private Sub cms_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles cms.ItemClicked
    '    Message.Add("Selection: " & e.ClickedItem.ToString & vbCrLf)
    'End Sub

    Private Sub ContextMenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        'Message.Add("Clicked:" & e.ClickedItem.ToString & vbCrLf)
        If e.ClickedItem.ToString = "Paste" Then
            pastefromclipboardtodatagridview(dgvMeasuredData)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save the well deviation data 
        'Check the file name.

        If Trim(txtFileName.Text) = "" Then
            Message.AddWarning("File name not specified." & vbCrLf)
            Exit Sub
        End If

        If Trim(txtFileName.Text).EndsWith(".WellDev") Then
        Else
            txtFileName.Text = Trim(txtFileName.Text) & ".WellDev"
        End If

        If FileName = "" Then
            'This is a new well record.
            FileName = txtFileName.Text
            SaveWellRecord(FileName)
        Else
            If FileName = txtFileName.Text Then
                'The well record will be updated.
                SaveWellRecord(FileName)
            Else
                'The well record will be saved using a new file name.

            End If
        End If



    End Sub

    Private Sub SaveWellRecord(ByVal FileName As String)
        'Save the well record as FileName.

        dgvMeasuredData.AllowUserToAddRows = False 'This removes the last edit row from the DataGridView.
        dgvCalculatedData.AllowUserToAddRows = False 'This removes the last edit row from the DataGridView.

        Dim wellData = <?xml version="1.0" encoding="utf-8"?>
                       <!---->
                       <!--Well deviation data.-->
                       <WellData>
                           <WellName><%= txtWellName.Text %></WellName>
                           <BoreholeName><%= txtBoreholeName.Text %></BoreholeName>
                           <RotaryTableHeight><%= txtRT.Text %></RotaryTableHeight>
                           <MeasuredDataUnits>
                               <Depth><%= cmbMeasDepthUnit.SelectedItem.ToString %></Depth>
                               <Angle><%= cmbMeasAngleUnit.SelectedItem.ToString %></Angle>
                               <NorthReference><%= cmbMeasNorthReference.SelectedItem.ToString %></NorthReference>
                           </MeasuredDataUnits>
                           <CalculatedDataUnits>
                               <Depth><%= cmbCalcDepthUnit.SelectedItem.ToString %></Depth>
                               <Offset><%= cmbCalcOffsetUnit.SelectedItem.ToString %></Offset>
                           </CalculatedDataUnits>
                           <SurfaceLocation>
                               <GeographicCRS><%= cmbGeoCRS.SelectedItem.ToString %></GeographicCRS>
                               <Latitude><%= txtLatitude.Text %></Latitude>
                               <Longitude><%= txtLongitude.Text %></Longitude>
                               <ProjectedCRS><%= cmbProjCRS.SelectedItem.ToString %></ProjectedCRS>
                               <Easting><%= txtEasting.Text %></Easting>
                               <Northing><%= txtNorthing.Text %></Northing>
                           </SurfaceLocation>
                           <MeasuredDeviationData>
                               <%= From Item In dgvMeasuredData.Rows()
                                   Select
                                   <DeviationRecord>
                                       <MeasuredDepth><%= Item.Cells(0).Value %></MeasuredDepth>
                                       <Inclination><%= Item.Cells(1).Value %></Inclination>
                                       <Azimuth><%= Item.Cells(2).Value %></Azimuth>
                                   </DeviationRecord>
                               %>
                           </MeasuredDeviationData>
                           <CalculatedDeviation>
                               <CalculationMethod><%= cmbCalcMethod.SelectedItem.ToString %></CalculationMethod>
                               <%= From Item In dgvCalculatedData.Rows()
                                   Select
                                        <CalculatedRecord>
                                            <TVDRT><%= Item.Cells(0).Value %></TVDRT>
                                            <dX><%= Item.Cells(1).Value %></dX>
                                            <dY><%= Item.Cells(2).Value %></dY>
                                            <TVDSS><%= Item.Cells(3).Value %></TVDSS>
                                            <Easting><%= Item.Cells(4).Value %></Easting>
                                            <Northing><%= Item.Cells(5).Value %></Northing>
                                        </CalculatedRecord>
                               %>
                           </CalculatedDeviation>
                       </WellData>

        '  <CalculationMethod><%= WellPathCalcMethod %></CalculationMethod>

        Project.SaveXmlData(FileName, wellData)

        dgvMeasuredData.AllowUserToAddRows = True 'Allow user to add rows again.
        dgvCalculatedData.AllowUserToAddRows = True 'Allow user to add rows again.

    End Sub


    Private Sub txtLatitude_TextChanged(sender As Object, e As EventArgs) Handles txtLatitude.TextChanged
        If txtLatitude.Focused Then
            Angle.DecimalDeg = txtLatitude.Text
            Angle.DecimalDegToDegMinSec()
            txtLatSign.Text = Angle.DegMinSec.SignSymbol
            txtLatDeg.Text = Angle.DegMinSec.Degrees
            txtLatMin.Text = Angle.DegMinSec.Minutes
            txtLatSec.Text = Angle.DegMinSec.Seconds
        End If
    End Sub

    Private Sub txtLongitude_TextChanged(sender As Object, e As EventArgs) Handles txtLongitude.TextChanged
        If txtLongitude.Focused Then
            Angle.DecimalDeg = txtLongitude.Text
            Angle.DecimalDegToDegMinSec()
            txtLongSign.Text = Angle.DegMinSec.SignSymbol
            txtLongDeg.Text = Angle.DegMinSec.Degrees
            txtLongMin.Text = Angle.DegMinSec.Minutes
            txtLongSec.Text = Angle.DegMinSec.Seconds
        End If
    End Sub

    Private Sub txtLatSign_TextChanged(sender As Object, e As EventArgs) Handles txtLatSign.TextChanged
        If txtLatSign.Focused Then
            UpdateDecimalLatitude()
        End If
    End Sub

    Private Sub txtLatDeg_TextChanged(sender As Object, e As EventArgs) Handles txtLatDeg.TextChanged
        If txtLatDeg.Focused Then
            UpdateDecimalLatitude()
        End If
    End Sub

    Private Sub txtLatMin_TextChanged(sender As Object, e As EventArgs) Handles txtLatMin.TextChanged
        If txtLatMin.Focused Then
            UpdateDecimalLatitude()
        End If
    End Sub

    Private Sub txtLatSec_TextChanged(sender As Object, e As EventArgs) Handles txtLatSec.TextChanged
        If txtLatSec.Focused Then
            UpdateDecimalLatitude()
        End If
    End Sub

    Private Sub UpdateDecimalLatitude()
        Angle.DegMinSec.SignSymbol = txtLatSign.Text
        Angle.DegMinSec.Degrees = Val(txtLatDeg.Text)
        Angle.DegMinSec.Minutes = Val(txtLatMin.Text)
        Angle.DegMinSec.Seconds = Val(txtLatSec.Text)
        Angle.DegMinSecToDecimalDeg()
        txtLatitude.Text = Angle.DecimalDeg
    End Sub

    Private Sub txtLongSign_TextChanged(sender As Object, e As EventArgs) Handles txtLongSign.TextChanged
        If txtLongSign.Focused Then
            UpdateDecimalLongitude()
        End If
    End Sub

    Private Sub txtLongDeg_TextChanged(sender As Object, e As EventArgs) Handles txtLongDeg.TextChanged
        If txtLongDeg.Focused Then
            UpdateDecimalLongitude()
        End If
    End Sub

    Private Sub txtLongMin_TextChanged(sender As Object, e As EventArgs) Handles txtLongMin.TextChanged
        If txtLongMin.Focused Then
            UpdateDecimalLongitude()
        End If
    End Sub

    Private Sub txtLongSec_TextChanged(sender As Object, e As EventArgs) Handles txtLongSec.TextChanged
        If txtLongSec.Focused Then
            UpdateDecimalLongitude()
        End If
    End Sub

    Private Sub UpdateDecimalLongitude()
        Angle.DegMinSec.SignSymbol = txtLongSign.Text
        Angle.DegMinSec.Degrees = Val(txtLongDeg.Text)
        Angle.DegMinSec.Minutes = Val(txtLongMin.Text)
        Angle.DegMinSec.Seconds = Val(txtLongSec.Text)
        Angle.DegMinSecToDecimalDeg()
        txtLongitude.Text = Angle.DecimalDeg
    End Sub


    'Private Sub ContextMenu_()

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        'Open a Well Deviation Data file.

        Select Case Project.DataLocn.Type
            Case ADVL_Utilities_Library_1.FileLocation.Types.Directory
                'Select an Area of Use list file from the project directory:
                OpenFileDialog1.InitialDirectory = Project.DataLocn.Path
                OpenFileDialog1.Filter = "Well Deviation Data | *.WellDev"
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    FileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                    OpenWellDevFile(FileName)
                End If
            Case ADVL_Utilities_Library_1.FileLocation.Types.Archive
                'Select an Area of Use list file from the project archive:
                'Show the zip archive file selection form:
                Zip = New ADVL_Utilities_Library_1.ZipComp
                Zip.ArchivePath = Project.DataLocn.Path
                Zip.SelectFile()
                'Zip.SelectFileForm.ApplicationName = Project.ApplicationName
                Zip.SelectFileForm.ApplicationName = Project.Application.Name
                Zip.SelectFileForm.SettingsLocn = Project.SettingsLocn
                Zip.SelectFileForm.Show()
                Zip.SelectFileForm.RestoreFormSettings()
                Zip.SelectFileForm.FileExtension = ".WellDev"
                Zip.SelectFileForm.GetFileList()
        End Select

    End Sub

    Private Sub Zip_FileSelected(FileName As String) Handles Zip.FileSelected
        Me.FileName = FileName
        OpenWellDevFile(FileName)
    End Sub

    Private Sub OpenWellDevFile(ByVal FileName As String)
        'Open the Well Deviation File with specified file name.

        If FileName = "" Then
            Exit Sub
        End If

        Dim wellData As System.Xml.Linq.XDocument
        Project.ReadXmlData(FileName, wellData)

        If wellData Is Nothing Then
            Message.AddWarning("No well data found for: " & FileName & vbCrLf)
            Exit Sub
        End If

        txtFileName.Text = FileName
        txtWellName.Text = wellData.<WellData>.<WellName>.Value
        txtBoreholeName.Text = wellData.<WellData>.<BoreholeName>.Value
        txtRT.Text = wellData.<WellData>.<RotaryTableHeight>.Value

        cmbMeasDepthUnit.SelectedIndex = cmbMeasDepthUnit.FindStringExact(wellData.<WellData>.<MeasuredDataUnits>.<Depth>.Value)
        cmbMeasAngleUnit.SelectedIndex = cmbMeasAngleUnit.FindStringExact(wellData.<WellData>.<MeasuredDataUnits>.<Angle>.Value)
        cmbMeasNorthReference.SelectedIndex = cmbMeasNorthReference.FindStringExact(wellData.<WellData>.<MeasuredDataUnits>.<NorthReference>.Value)

        cmbCalcDepthUnit.SelectedIndex = cmbCalcDepthUnit.FindStringExact(wellData.<WellData>.<CalculatedDataUnits>.<Depth>.Value)
        cmbCalcOffsetUnit.SelectedIndex = cmbCalcOffsetUnit.FindStringExact(wellData.<WellData>.<CalculatedDataUnits>.<Offset>.Value)

        cmbGeoCRS.SelectedIndex = cmbGeoCRS.FindStringExact(wellData.<WellData>.<SurfaceLocation>.<GeographicCRS>.Value)

        txtLatitude.Text = wellData.<WellData>.<SurfaceLocation>.<Latitude>.Value
        Angle.DecimalDeg = txtLatitude.Text
        Angle.DecimalDegToDegMinSec()
        txtLatSign.Text = Angle.DegMinSec.SignSymbol
        txtLatDeg.Text = Angle.DegMinSec.Degrees
        txtLatMin.Text = Angle.DegMinSec.Minutes
        txtLatSec.Text = Angle.DegMinSec.Seconds

        txtLongitude.Text = wellData.<WellData>.<SurfaceLocation>.<Longitude>.Value
        Angle.DecimalDeg = txtLongitude.Text
        Angle.DecimalDegToDegMinSec()
        txtLongSign.Text = Angle.DegMinSec.SignSymbol
        txtLongDeg.Text = Angle.DegMinSec.Degrees
        txtLongMin.Text = Angle.DegMinSec.Minutes
        txtLongSec.Text = Angle.DegMinSec.Seconds

        cmbProjCRS.SelectedIndex = cmbProjCRS.FindStringExact(wellData.<WellData>.<SurfaceLocation>.<ProjectedCRS>.Value)
        txtEasting.Text = wellData.<WellData>.<SurfaceLocation>.<Easting>.Value
        txtNorthing.Text = wellData.<WellData>.<SurfaceLocation>.<Northing>.Value

        'Read the Measured Deviation Data:
        dgvMeasuredData.Rows.Clear()
        'Dim LastRow As Integer
        'dgvMeasuredData.EditMode = DataGridViewEditMode.EditProgrammatically
        For Each Item In wellData.<WellData>.<MeasuredDeviationData>.<DeviationRecord>
            dgvMeasuredData.Rows.Add(Item.<MeasuredDepth>.Value, Item.<Inclination>.Value, Item.<Azimuth>.Value)
        Next

        'Read the Calculation Method:
        'If wellData.<CalculatedDeviation>.<CalculationMethod>.Value = Nothing Then
        '    WellPathCalcMethod = WellPathCalcMethods.MinimumCurvature
        'Else
        '    WellPathCalcMethod = wellData.<WellData>.<CalculatedDeviation>.<CalculationMethod>.Value
        'End If

        cmbCalcMethod.SelectedIndex = cmbCalcMethod.FindStringExact(wellData.<WellData>.<CalculatedDeviation>.<CalculationMethod>.Value)

        'Read the Calculated Deviation Data:
        dgvCalculatedData.Rows.Clear()
        For Each Item In wellData.<WellData>.<CalculatedDeviation>.<CalculatedRecord>
            dgvCalculatedData.Rows.Add(Item.<TVDRT>.Value, Item.<dX>.Value, Item.<dY>.Value, Item.<TVDSS>.Value, Item.<Easting>.Value, Item.<Northing>.Value)
        Next

        DisplayWellPaths()

    End Sub

    Private Sub btnCalculateProjCoords_Click(sender As Object, e As EventArgs) Handles btnCalculateProjCoords.Click
        'Calculate the projected coordinates from the Latitude and Longitude values.

        'Create the XML instructions to convert the angles:
        Dim decl As New XDeclaration("1.0", "utf-8", "yes")
        Dim doc As New XDocument(decl, Nothing) 'Create an XDocument to store the instructions.
        Dim xmessage As New XElement("XMsg") 'This indicates the start of the message in the XMessage class

        'ADDED 3Feb19:
        'Dim clientAppNetName As New XElement("ClientAppNetName", AppNetName)
        'xmessage.Add(clientAppNetName)
        Dim clientProjectNetName As New XElement("ClientProNetName", ProNetName)
        xmessage.Add(clientProjectNetName)

        Dim clientName As New XElement("ClientName", ApplicationInfo.Name) 'This tells the coordinate server the name of the client making the request.
        xmessage.Add(clientName)
        Dim operation As New XElement("ConvertProjectedCoordinates") 'This is used to convert between projected and geographic coordinates.

        Dim projectedCRS As New XElement("ProjectedCRS", cmbProjCRS.SelectedItem.ToString)
        operation.Add(projectedCRS)

        Dim inputCoordinates As New XElement("InputCoordinates")

        Dim Type As New XElement("Type", "Geographic")
        inputCoordinates.Add(Type)
        Dim LatitudeDecimalDegrees As New XElement("LatitudeDecimalDegrees", txtLatitude.Text)
        inputCoordinates.Add(LatitudeDecimalDegrees)
        Dim LongitudeDecimalDegrees As New XElement("LongitudeDecimalDegrees", txtLongitude.Text)
        inputCoordinates.Add(LongitudeDecimalDegrees)

        operation.Add(inputCoordinates)

        Dim outputCoordinates As New XElement("OutputCoordinates")

        Dim outputType As New XElement("Type", "Projected")
        outputCoordinates.Add(outputType)

        Dim EastingUnits As New XElement("EastingUnits", "Default")
        outputCoordinates.Add(EastingUnits)
        Dim NorthingUnits As New XElement("NorthingUnits", "Default")
        outputCoordinates.Add(NorthingUnits)

        operation.Add(outputCoordinates)

        Dim command As New XElement("Command", "ConvertCoordinates")
        operation.Add(command)

        xmessage.Add(operation)
        doc.Add(xmessage)

        If IsNothing(client) Then
            Message.Add("No client connection available!" & vbCrLf)
        Else
            If client.State = ServiceModel.CommunicationState.Faulted Then
                Message.Add("client state is faulted. Messge not sent!" & vbCrLf)
            Else
                'client.SendMessageAsync("ADVL_Coordinates_1", doc.ToString)
                'client.SendMessageAsync(AppNetName, "ADVL_Coordinates_1", doc.ToString)
                client.SendMessageAsync(ProNetName, "ADVL_Coordinates_1", doc.ToString)

                'Message.Color = Color.Red
                'Message.FontStyle = FontStyle.Bold
                'Message.XAdd("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf)
                'Message.SetNormalStyle()
                'Message.XAdd(doc.ToString & vbCrLf & vbCrLf)
                'Message.XAddText("Message sent to " & "ADVL_Coordinates_1" & ":" & vbCrLf, "XmlSentNotice")
                Message.XAddText("Message sent to [" & ProNetName & "]." & "ADVL_Coordinates_1" & ":" & vbCrLf, "XmlSentNotice")
                Message.XAddXml(doc.ToString)
                Message.XAddText(vbCrLf, "Message") 'Add extra line

            End If
        End If




    End Sub

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        'Add a row to the Measured Data grid.

        'Dim SelectedRow As Integer = dgvMeasuredData.SelectedRows(0).Index

        'dgvMeasuredData.Rows.Add(SelectedRow)
        dgvMeasuredData.Rows.Add()

    End Sub

    'Private Sub btnNoEdits_Click(sender As Object, e As EventArgs) Handles btnNoEdits.Click
    '    dgvMeasuredData.AllowUserToAddRows = False
    'End Sub

    'Private Sub btnAllowEdits_Click(sender As Object, e As EventArgs) Handles btnAllowEdits.Click
    '    dgvMeasuredData.AllowUserToAddRows = True
    'End Sub

    Private Sub btnCalculateWellPath_Click(sender As Object, e As EventArgs) Handles btnCalculateWellPath.Click
        'Calculate the well path from the measured Depth, Inclination and Azimuth data.

        Select Case cmbCalcMethod.SelectedItem.ToString
            Case "Average Angle"

            Case "Balanced Angle"

            Case "Minimum Curvature"
                'WellPathCalcMethod = WellPathCalcMethods.MinimumCurvature
                MinCurvatureWellPath()
            Case "Radius of Curvature"

            Case "Tangential"




        End Select
    End Sub

    Private Sub MinCurvatureWellPath()
        'Calculate the well path using minimum curvature method.

        Dim Incline1Radians As Double 'The incline 1 (shallow) value converted to radians
        Dim Incline2Radians As Double 'The incline 2 value converted to radians
        Dim Azimuth1Radians As Double
        Dim Azimuth2Radians As Double
        Dim DL As Double
        Dim RF As Double 'Ratio Factor
        Dim Dinc As Double
        Dim DepthRT As Double 'Depth RT
        Dim DepthSS As Double 'Depth Subsea
        Dim Xinc As Double
        Dim Yinc As Double
        Dim Dx As Double
        Dim Dy As Double

        Dim RT As Double = Val(txtRT.Text)
        Dim SurfaceEasting As Double = Val(txtEasting.Text)
        Dim Easting As Double
        Dim SurfaceNorthing As Double = Val(txtNorthing.Text)
        Dim Northing As Double


        Dim NPoints As Integer
        If dgvMeasuredData.AllowUserToAddRows = True Then
            NPoints = dgvMeasuredData.Rows.Count - 1
        Else
            NPoints = dgvMeasuredData.Rows.Count
        End If

        Dim I As Integer 'Loop index
        dgvCalculatedData.Rows.Clear()
        dgvCalculatedData.Rows.Add(0, 0, 0, 0 - RT, SurfaceEasting, SurfaceNorthing)
        For I = 1 To NPoints - 1
            Incline1Radians = dgvMeasuredData.Rows(I - 1).Cells(1).Value * Math.PI / 180
            Incline2Radians = dgvMeasuredData.Rows(I).Cells(1).Value * Math.PI / 180
            Azimuth1Radians = dgvMeasuredData.Rows(I - 1).Cells(2).Value * Math.PI / 180
            Azimuth2Radians = dgvMeasuredData.Rows(I).Cells(2).Value * Math.PI / 180


            DL = Math.Acos(Math.Cos(Incline1Radians) * Math.Cos(Incline2Radians) + Math.Sin(Incline1Radians) * Math.Sin(Incline2Radians) * Math.Cos(Azimuth2Radians - Azimuth1Radians))
            If DL = 0 Then
                RF = 1
            Else
                RF = 2 / DL * Math.Tan(DL / 2)
            End If

            Dinc = (dgvMeasuredData.Rows(I).Cells(0).Value - dgvMeasuredData.Rows(I - 1).Cells(0).Value) / 2 * (Math.Cos(Incline1Radians) + Math.Cos(Incline2Radians)) * RF
            DepthRT = dgvCalculatedData.Rows(I - 1).Cells(0).Value + Dinc
            DepthSS = DepthRT - RT
            Xinc = (dgvMeasuredData.Rows(I).Cells(0).Value - dgvMeasuredData.Rows(I - 1).Cells(0).Value) / 2 * (Math.Sin(Incline1Radians) * Math.Sin(Azimuth1Radians) + Math.Sin(Incline2Radians) * Math.Sin(Azimuth2Radians)) * RF
            Dx = dgvCalculatedData.Rows(I - 1).Cells(1).Value + Xinc
            Easting = SurfaceEasting + Dx
            Yinc = (dgvMeasuredData.Rows(I).Cells(0).Value - dgvMeasuredData.Rows(I - 1).Cells(0).Value) / 2 * (Math.Sin(Incline1Radians) * Math.Cos(Azimuth1Radians) + Math.Sin(Incline2Radians) * Math.Cos(Azimuth2Radians)) * RF
            Dy = dgvCalculatedData.Rows(I - 1).Cells(2).Value + Yinc
            Northing = SurfaceNorthing + Dy
            dgvCalculatedData.Rows.Add(DepthRT, Dx, Dy, DepthSS, Easting, Northing)

        Next

        'Redisplay calculated values with formatting applied:
        Dim CalcDepthDecPl As Integer = Int(Val(txtCalcDepthDecPl.Text))
        Dim CalcOffsetDecPl As Integer = Int(Val(txtCalcOffsetDecPl.Text))
        Dim CalcDepthFormatStr As String = StrDup(CalcDepthDecPl, "0")
        Dim CalcOffsetFormatStr As String = StrDup(CalcOffsetDecPl, "0")
        For I = 1 To NPoints
            dgvCalculatedData.Rows(I - 1).Cells(0).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(0).Value, "###0." & CalcDepthFormatStr) 'TVD RT
            dgvCalculatedData.Rows(I - 1).Cells(1).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(1).Value, "###0." & CalcOffsetFormatStr) 'dX
            dgvCalculatedData.Rows(I - 1).Cells(2).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(2).Value, "###0." & CalcOffsetFormatStr) 'dY
            dgvCalculatedData.Rows(I - 1).Cells(3).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(3).Value, "###0." & CalcDepthFormatStr) 'TVD Subsea
            dgvCalculatedData.Rows(I - 1).Cells(4).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(4).Value, "#,###,###." & CalcOffsetFormatStr) 'Easting
            dgvCalculatedData.Rows(I - 1).Cells(5).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(5).Value, "#,###,###." & CalcOffsetFormatStr) 'Northing

        Next

        DisplayWellPaths()

    End Sub

    Private Sub cmbMeasDepthUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMeasDepthUnit.SelectedIndexChanged
        Select Case cmbMeasDepthUnit.SelectedItem.ToString
            Case "Feet"
                DepthUnit = DepthUnits.foot
            Case "Metres"
                DepthUnit = DepthUnits.metre
        End Select
    End Sub

    Private Sub cmbMeasAngleUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMeasAngleUnit.SelectedIndexChanged
        Select Case cmbMeasAngleUnit.SelectedItem.ToString
            Case "Radians"
                AngleUnit = AngleUnits.radian
            Case "Degrees"
                AngleUnit = AngleUnits.degree
        End Select
    End Sub

    Private Sub cmbMeasNorthReference_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMeasNorthReference.SelectedIndexChanged
        Select Case cmbMeasNorthReference.SelectedItem.ToString
            Case "Magnetic North"
                NorthReference = NorthReferences.MagneticNorth
            Case "True North"
                NorthReference = NorthReferences.TrueNorth
            Case "Grid North"
                NorthReference = NorthReferences.GridNorth
        End Select
    End Sub

    Private Sub cmbCalcDepthUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalcDepthUnit.SelectedIndexChanged
        Select Case cmbCalcDepthUnit.SelectedItem.ToString
            Case "Foot"
                CalcDepthUnit = DepthUnits.foot
            Case "Metre"
                CalcDepthUnit = DepthUnits.metre
        End Select
    End Sub

    Private Sub cmbCalcOffsetUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalcOffsetUnit.SelectedIndexChanged
        Select Case cmbCalcOffsetUnit.SelectedItem.ToString
            Case "Foot"
                CalcOffsetUnit = DistanceUnits.foot
            Case "Metre"
                CalcOffsetUnit = DistanceUnits.metre
        End Select
    End Sub



    'Private Sub cmbCalcMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCalcMethod.SelectedIndexChanged
    '    Select Case cmbCalcMethod.SelectedItem.ToString
    '        Case "Average Angle"
    '            _wellPathCalcMethod = WellPathCalcMethods.AverageAngle
    '        Case "Balanced Angle"
    '            _wellPathCalcMethod = WellPathCalcMethods.BalancedAngle
    '        Case "Minimum Curvature"
    '            _wellPathCalcMethod = WellPathCalcMethods.MinimumCurvature
    '        Case "Radius of Curvature"
    '            _wellPathCalcMethod = WellPathCalcMethods.RadiusOfCurvature
    '        Case "Tangential"
    '            _wellPathCalcMethod = WellPathCalcMethods.Tangential
    '    End Select
    'End Sub




    Private Sub DisplayWellPaths()
        Chart1.Series.Clear()
        Chart1.Series.Add("XProfile")
        Chart1.Series("XProfile").YValuesPerPoint = 1

        Chart2.Series.Clear()
        Chart2.Series.Add("YProfile")
        Chart2.Series("YProfile").YValuesPerPoint = 1

        Chart3.Series.Clear()
        Chart3.Series.Add("XYPlot")
        Chart3.Series("XYPlot").YValuesPerPoint = 1

        'Chart1.Series("XProfile").ChartType = DataVisualization.Charting.SeriesChartType.Line
        'Chart1.Series("XProfile").ChartType = DataVisualization.Charting.SeriesChartType.Point
        'Chart1.Series("XProfile").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("XProfile").ChartType = DataVisualization.Charting.SeriesChartType.Spline
        'Chart2.Series("YProfile").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart2.Series("YProfile").ChartType = DataVisualization.Charting.SeriesChartType.Spline
        'Chart3.Series("XYPlot").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart3.Series("XYPlot").ChartType = DataVisualization.Charting.SeriesChartType.Spline

        Dim I As Integer
        For I = 1 To dgvCalculatedData.RowCount - 1
            Chart1.Series("XProfile").Points.AddXY(Val(dgvCalculatedData.Rows(I - 1).Cells(1).Value), dgvCalculatedData.Rows(I - 1).Cells(0).Value)
            'Debug.Print("X: " & dgvCalculatedData.Rows(I - 1).Cells(1).Value & "   Y: " & dgvCalculatedData.Rows(I - 1).Cells(0).Value)
            Chart2.Series("YProfile").Points.AddXY(Val(dgvCalculatedData.Rows(I - 1).Cells(2).Value), dgvCalculatedData.Rows(I - 1).Cells(0).Value)
            Chart3.Series("XYPlot").Points.AddXY(Val(dgvCalculatedData.Rows(I - 1).Cells(1).Value), Val(dgvCalculatedData.Rows(I - 1).Cells(2).Value))
        Next



        'Dont show the data legends:
        Chart1.Series("XProfile").IsVisibleInLegend = False
        Chart2.Series("YProfile").IsVisibleInLegend = False
        Chart3.Series("XYPlot").IsVisibleInLegend = False

        'Show the well depths increasing downwards:
        Chart1.ChartAreas(0).AxisY.IsReversed = True
        Chart2.ChartAreas(0).AxisY.IsReversed = True

        'Chart1.ChartAreas(0).AxisX.Minimum = -1
        'Chart1.ChartAreas(0).AxisX.Maximum = 10

        Chart1.Series("XProfile").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle

        'Chart2.ChartAreas(0).AxisX.Minimum = -1
        'Chart2.ChartAreas(0).AxisX.Maximum = 20

        Chart2.Series("YProfile").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle


        Chart3.Series("XYPlot").MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle


        'Show chart titles:
        If Chart1.Titles.IndexOf("Label1") = -1 Then 'Label "Label1" doesnt exist.
            Chart1.Titles.Add("Label1").Name = "Label1" 'The name must be explicitly declared!
        End If
        Chart1.Titles("Label1").Text = "West - East Well Deviation Section"
        Chart1.Titles("Label1").Font = New Drawing.Font("Arial", 12, Drawing.FontStyle.Bold)
        Chart1.Titles("Label1").Alignment = ContentAlignment.TopCenter

        If Chart2.Titles.IndexOf("Label1") = -1 Then 'Label "Label1" doesnt exist.
            Chart2.Titles.Add("Label1").Name = "Label1" 'The name must be explicitly declared!
        End If
        Chart2.Titles("Label1").Text = "South - North Well Deviation Section"
        Chart2.Titles("Label1").Font = New Drawing.Font("Arial", 12, Drawing.FontStyle.Bold)
        Chart2.Titles("Label1").Alignment = ContentAlignment.TopCenter

        If Chart3.Titles.IndexOf("Label1") = -1 Then 'Label "Label1" doesnt exist.
            Chart3.Titles.Add("Label1").Name = "Label1" 'The name must be explicitly declared!
        End If
        Chart3.Titles("Label1").Text = "Plan View of Well Deviation"
        Chart3.Titles("Label1").Font = New Drawing.Font("Arial", 12, Drawing.FontStyle.Bold)
        Chart3.Titles("Label1").Alignment = ContentAlignment.TopCenter

        Chart1.ChartAreas(0).AxisX.TitleFont = New Drawing.Font("Arial", 11, Drawing.FontStyle.Bold)
        If _calcOffsetUnit = DistanceUnits.foot Then
            Chart1.ChartAreas(0).AxisX.Title = "X Deviation" & " (Feet)"
        Else
            Chart1.ChartAreas(0).AxisX.Title = "X Deviation" & " (" & _calcOffsetUnit.ToString & "s)"
        End If

        'Chart1.ChartAreas(0).AxisY.Title = "Depth RT"
        'Chart1.ChartAreas(0).AxisY.TitleFont = New Drawing.Font("Arial", 11, Drawing.FontStyle.Regular)
        Chart1.ChartAreas(0).AxisY.TitleFont = New Drawing.Font("Arial", 11, Drawing.FontStyle.Bold)
        If _depthUnit = DepthUnits.foot Then
            Chart1.ChartAreas(0).AxisY.Title = "Measured Depth RT" & " (Feet RT)"
        Else
            Chart1.ChartAreas(0).AxisY.Title = "Measured Depth" & " (" & _depthUnit.ToString & "s RT)"
        End If

        Chart2.ChartAreas(0).AxisX.TitleFont = New Drawing.Font("Arial", 11, Drawing.FontStyle.Bold)
        If _calcOffsetUnit = DistanceUnits.foot Then
            Chart2.ChartAreas(0).AxisX.Title = "Y Deviation" & " (Feet)"
        Else
            Chart2.ChartAreas(0).AxisX.Title = "Y Deviation" & " (" & _calcOffsetUnit.ToString & "s)"
        End If

        Chart2.ChartAreas(0).AxisY.TitleFont = New Drawing.Font("Arial", 11, Drawing.FontStyle.Bold)
        If _depthUnit = DepthUnits.foot Then
            Chart2.ChartAreas(0).AxisY.Title = "Measured Depth RT" & " (Feet RT)"
        Else
            Chart2.ChartAreas(0).AxisY.Title = "Measured Depth" & " (" & _depthUnit.ToString & "s RT)"
        End If

        Chart3.ChartAreas(0).AxisX.TitleFont = New Drawing.Font("Arial", 11, Drawing.FontStyle.Bold)
        If _calcOffsetUnit = DistanceUnits.foot Then
            Chart3.ChartAreas(0).AxisX.Title = "X Deviation" & " (Feet)"
        Else
            Chart3.ChartAreas(0).AxisX.Title = "X Deviation" & " (" & _calcOffsetUnit.ToString & "s)"
        End If

        Chart3.ChartAreas(0).AxisY.TitleFont = New Drawing.Font("Arial", 11, Drawing.FontStyle.Bold)
        If _depthUnit = DepthUnits.foot Then
            Chart3.ChartAreas(0).AxisY.Title = "Y Deviation" & " (Feet)"
        Else
            Chart3.ChartAreas(0).AxisY.Title = "Y Deviation" & " (" & _calcOffsetUnit.ToString & "s)"
        End If



    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'New Well Deviation.

        FileName = ""
        WellName = ""
        Borehole = ""
        txtRT.Text = ""
        txtLatitude.Text = ""
        txtLongitude.Text = ""
        txtLatSign.Text = ""
        txtLatDeg.Text = ""
        txtLatMin.Text = ""
        txtLatSec.Text = ""
        txtLongSign.Text = ""
        txtLongDeg.Text = ""
        txtLongMin.Text = ""
        txtLongSec.Text = ""
        txtEasting.Text = ""
        txtNorthing.Text = ""

        dgvMeasuredData.Rows.Clear()
        dgvCalculatedData.Rows.Clear()
        DisplayWellPaths()

    End Sub

    Private Sub txtInputDepthValue_TextChanged(sender As Object, e As EventArgs) Handles txtInputDepthValue.TextChanged
        InterpolateValues()
    End Sub

    Private Sub InterpolateValues()
        'Interpolate values at the Input Depth location.

        Select Case cmbInterpolationType.SelectedItem.ToString
            Case "Linear"
                LinearInterpolateValues()
            Case "Cubic Spline"

        End Select
    End Sub

    Private Sub LinearInterpolateValues()
        'Linear Interpolate values at the Input Depth location


        Dim CalcDepthDecPl As Integer = Int(Val(txtCalcDepthDecPl.Text))
        Dim CalcOffsetDecPl As Integer = Int(Val(txtCalcOffsetDecPl.Text))
        Dim CalcDepthFormatStr As String = StrDup(CalcDepthDecPl, "0")
        Dim CalcOffsetFormatStr As String = StrDup(CalcOffsetDecPl, "0")


        Select Case cmbInputDepth.SelectedItem.ToString
            Case "Measured Depth RT"
                'Get X1 first grid row number
                Dim XVal As Double = Val(txtInputDepthValue.Text)
                Dim NRows As Integer = dgvMeasuredData.RowCount
                Dim X1RowNo As Integer = 1 'First row is 1. 
                Dim X2RowNo As Integer = NRows  'Last row is NRows. 
                Dim XMidRowNo As Integer 'Mid row number
                Dim X1 As Double 'The value at X1RowNo
                Dim X2 As Double 'The value as X2RowNo
                Dim XMid As Double 'The value at XMidRowNo
                While X2RowNo - X1RowNo > 1
                    XMidRowNo = Int((X1RowNo + X2RowNo) / 2)
                    X1 = dgvMeasuredData.Rows(X1RowNo - 1).Cells(0).Value
                    X2 = dgvMeasuredData.Rows(X2RowNo - 1).Cells(0).Value
                    XMid = dgvMeasuredData.Rows(XMidRowNo - 1).Cells(0).Value
                    'If XVal >= XMid Then
                    If XVal > XMid Then
                        X1RowNo = XMidRowNo
                    Else
                        X2RowNo = XMidRowNo
                    End If
                End While

                'X1RowNo and X2RowNo are the rows that will be used for interpolation.
                X1 = dgvMeasuredData.Rows(X1RowNo - 1).Cells(0).Value
                X2 = dgvMeasuredData.Rows(X2RowNo - 1).Cells(0).Value
                'Interpolate True Vertical Depth RT
                Dim Y1 As Double = dgvCalculatedData.Rows(X1RowNo - 1).Cells(0).Value
                Dim Y2 As Double = dgvCalculatedData.Rows(X2RowNo - 1).Cells(0).Value
                txtInterpolatedTVDRT.Text = LinearInterpolation(XVal, X1, X2, Y1, Y2)
                'Interpolate True Vertical Depth Subsea
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(3).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(3).Value
                txtInterpolatedTVDSS.Text = LinearInterpolation(XVal, X1, X2, Y1, Y2)
                'Interpolate dX
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(1).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(1).Value
                txtInterpolateddX.Text = LinearInterpolation(XVal, X1, X2, Y1, Y2)
                'Interpolate dY
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(2).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(2).Value
                txtInterpolateddY.Text = LinearInterpolation(XVal, X1, X2, Y1, Y2)
                'Interpolate Easting
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(4).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(4).Value
                txtInterpolatedEasting.Text = LinearInterpolation(XVal, X1, X2, Y1, Y2)
                'Interpolate Northing
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(5).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(5).Value
                txtInterpolatedNorthing.Text = LinearInterpolation(XVal, X1, X2, Y1, Y2)

            Case "Measured Depth Subsea"
                'Get X1 first grid row number
                Dim XVal As Double = Val(txtInputDepthValue.Text) + Val(txtRT.Text) 'Convert to Measured Depth RT
                Dim NRows As Integer = dgvMeasuredData.RowCount
                Dim X1RowNo As Integer = 1 'First row is 1. 
                Dim X2RowNo As Integer = NRows  'Last row is NRows. 
                Dim XMidRowNo As Integer 'Mid row number
                Dim X1 As Double 'The value at X1RowNo
                Dim X2 As Double 'The value as X2RowNo
                Dim XMid As Double 'The value at XMidRowNo
                While X2RowNo - X1RowNo > 1
                    XMidRowNo = Int((X1RowNo + X2RowNo) / 2)
                    X1 = dgvMeasuredData.Rows(X1RowNo - 1).Cells(0).Value
                    X2 = dgvMeasuredData.Rows(X2RowNo - 1).Cells(0).Value
                    XMid = dgvMeasuredData.Rows(XMidRowNo - 1).Cells(0).Value
                    'If XVal >= XMid Then
                    If XVal > XMid Then
                        X1RowNo = XMidRowNo
                    Else
                        X2RowNo = XMidRowNo
                    End If
                End While

                'X1RowNo and X2RowNo are the rows that will be used for interpolation.
                X1 = dgvMeasuredData.Rows(X1RowNo - 1).Cells(0).Value
                X2 = dgvMeasuredData.Rows(X2RowNo - 1).Cells(0).Value
                'Interpolate True Vertical Depth RT
                Dim Y1 As Double = dgvCalculatedData.Rows(X1RowNo - 1).Cells(0).Value
                Dim Y2 As Double = dgvCalculatedData.Rows(X2RowNo - 1).Cells(0).Value
                txtInterpolatedTVDRT.Text = Format(LinearInterpolation(XVal, X1, X2, Y1, Y2), "###0." & CalcDepthFormatStr)
                'Interpolate True Vertical Depth Subsea
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(3).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(3).Value
                txtInterpolatedTVDSS.Text = Format(LinearInterpolation(XVal, X1, X2, Y1, Y2), "###0." & CalcDepthFormatStr)
                'Interpolate dX
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(1).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(1).Value
                txtInterpolateddX.Text = Format(LinearInterpolation(XVal, X1, X2, Y1, Y2), "###0." & CalcOffsetFormatStr)
                'Interpolate dY
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(2).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(2).Value
                txtInterpolateddY.Text = Format(LinearInterpolation(XVal, X1, X2, Y1, Y2), "###0." & CalcOffsetFormatStr)
                'Interpolate Easting
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(4).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(4).Value
                txtInterpolatedEasting.Text = Format(LinearInterpolation(XVal, X1, X2, Y1, Y2), "#,###,###." & CalcOffsetFormatStr)
                'Interpolate Northing
                Y1 = dgvCalculatedData.Rows(X1RowNo - 1).Cells(5).Value
                Y2 = dgvCalculatedData.Rows(X2RowNo - 1).Cells(5).Value
                txtInterpolatedNorthing.Text = Format(LinearInterpolation(XVal, X1, X2, Y1, Y2), "#,###,###." & CalcOffsetFormatStr)
        End Select

        'dgvCalculatedData.Rows(I - 1).Cells(0).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(0).Value, "###0." & CalcDepthFormatStr) 'TVD RT
        'dgvCalculatedData.Rows(I - 1).Cells(1).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(1).Value, "###0." & CalcOffsetFormatStr) 'dX
        'dgvCalculatedData.Rows(I - 1).Cells(2).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(2).Value, "###0." & CalcOffsetFormatStr) 'dY
        'dgvCalculatedData.Rows(I - 1).Cells(3).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(3).Value, "###0." & CalcDepthFormatStr) 'TVD Subsea
        'dgvCalculatedData.Rows(I - 1).Cells(4).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(4).Value, "#,###,###." & CalcOffsetFormatStr) 'Easting
        'dgvCalculatedData.Rows(I - 1).Cells(5).Value = Format(dgvCalculatedData.Rows(I - 1).Cells(5).Value, "#,###,###." & CalcOffsetFormatStr) 'Northing

    End Sub

    Private Function LinearInterpolation(ByVal X As Double, ByVal X1 As Double, ByVal X2 As Double, ByVal Y1 As Double, ByVal Y2 As Double) As Double
        'Function calculates the linear interpolated value Y at location X.
        'Input parameters are X, X1, X2, Y1 and Y2.

        Return Y1 + (X - X1) * (Y2 - Y1) / (X2 - X1)

    End Function

    Private Sub ApplicationInfo_UpdateExePath() Handles ApplicationInfo.UpdateExePath
        'Update the Executable Path.
        ApplicationInfo.ExecutablePath = Application.ExecutablePath
    End Sub

    Private Sub Project_NewProjectCreated(ProjectPath As String) Handles Project.NewProjectCreated
        SendProjectInfo(ProjectPath) 'Send the path of the new project to the Network application. The new project will be added to the list of projects.
    End Sub

#End Region 'Form Methods ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Class clsAngle
        'Converts between decimal degrees and degress, minutes, seconds.

        Property DegMinSec As New clsDegMinSec 'An angle stored as AngleSign, Degrees, Minutes and Seconds.
        Property DecimalDeg As Double 'An angle stored as decimal degrees.

        Sub DecimalDegToDegMinSec()
            'Convert decimal degrees to degrees minutes and seconds.
            Dim AbsDecimalDegrees As Double
            If DecimalDeg < 0 Then
                AbsDecimalDegrees = Math.Abs(DecimalDeg)
                DegMinSec.Sign = clsDegMinSec.Signs.Negative
            Else
                AbsDecimalDegrees = DecimalDeg
                DegMinSec.Sign = clsDegMinSec.Signs.Positive
            End If

            'DmsDegrees = Fix(AbsDecimalDegrees)
            DegMinSec.Degrees = Fix(AbsDecimalDegrees)
            Dim DecimalMinutes As Double
            'DecimalMinutes = (AbsDecimalDegrees - DmsDegrees) * 60
            DecimalMinutes = (AbsDecimalDegrees - DegMinSec.Degrees) * 60
            'DmsMinutes = Fix(DecimalMinutes)
            DegMinSec.Minutes = Fix(DecimalMinutes)
            Dim RawSeconds As Decimal
            'RawSeconds = (DecimalMinutes - DmsMinutes) * 60
            RawSeconds = (DecimalMinutes - DegMinSec.Minutes) * 60
            Dim RoundedSeconds As Decimal
            'RoundedSeconds = System.Decimal.Round(RawSeconds, DmsSecondsDecimalPlaces)
            RoundedSeconds = System.Decimal.Round(RawSeconds, DegMinSec.SecondsDecimalPlaces)
            'Check if RoundedSeconds > 60
            If RoundedSeconds >= 60 Then
                'DmsMinutes = DmsMinutes + 1
                DegMinSec.Minutes = DegMinSec.Minutes + 1
                RoundedSeconds = 0
                'If DmsMinutes >= 60 Then
                If DegMinSec.Minutes >= 60 Then
                    'DmsDegrees = DmsDegrees + 1
                    DegMinSec.Degrees = DegMinSec.Degrees + 1
                    'DmsMinutes = 0
                    DegMinSec.Minutes = 0
                End If
            ElseIf RoundedSeconds <= -60 Then
                'DmsMinutes = DmsMinutes - 1
                DegMinSec.Minutes = DegMinSec.Minutes - 1
                RoundedSeconds = 0
                'If DmsMinutes <= -60 Then
                If DegMinSec.Minutes <= -60 Then
                    'DmsDegrees = DmsDegrees - 1
                    DegMinSec.Degrees = DegMinSec.Degrees - 1
                    'DmsMinutes = 0
                    DegMinSec.Minutes = 0
                End If
            End If
            'DmsSeconds = RoundedSeconds
            DegMinSec.Seconds = RoundedSeconds
        End Sub

        Sub DegMinSecToDecimalDeg()
            'Convert degrees minutes and seconds to decimal degrees.
            'If DmsSign = Sign.Negative Then
            If DegMinSec.Sign = clsDegMinSec.Signs.Negative Then
                'DecimalDegrees = (DmsDegrees + DmsMinutes / 60 + DmsSeconds / 3600) * -1
                DecimalDeg = (DegMinSec.Degrees + DegMinSec.Minutes / 60 + DegMinSec.Seconds / 3600) * -1
            Else
                'DecimalDegrees = DmsDegrees + DmsMinutes / 60 + DmsSeconds / 3600
                DecimalDeg = DegMinSec.Degrees + DegMinSec.Minutes / 60 + DegMinSec.Seconds / 3600
            End If
        End Sub

    End Class

    Private Class clsDegMinSec
        'Stores and angle as degrees, minutes, seconds
        Enum Signs
            Positive
            Negative
        End Enum
        Private _sign As Signs = Signs.Positive
        Property Sign As Signs
            Get
                Return _sign
            End Get
            Set(value As Signs)
                _sign = value
                If _sign = Signs.Negative Then
                    _signSymbol = "-"
                Else
                    _signSymbol = "+"
                End If
            End Set
        End Property

        Private _signSymbol As String = "+"
        Property SignSymbol As String
            Get
                Return _signSymbol
            End Get
            Set(value As String)
                _signSymbol = value
                If value = "+" Then
                    _sign = Signs.Positive
                ElseIf value = "-" Then
                    _sign = Signs.Negative
                ElseIf value = "" Then
                    _sign = Signs.Positive
                Else
                    _signSymbol = "+"
                    _sign = Signs.Positive
                End If
            End Set
        End Property

        Property Degrees As Integer
        Property Minutes As Integer
        Property SecondsDecimalPlaces As Integer = 8 'The number of decimal places used to display the seconds value.
        Property Seconds As Double

    End Class



    Private Sub chkConnect_LostFocus(sender As Object, e As EventArgs) Handles chkConnect.LostFocus
        If chkConnect.Checked Then
            Project.ConnectOnOpen = True
        Else
            Project.ConnectOnOpen = False
        End If
        Project.SaveProjectInfoFile()

    End Sub

    'Private Sub Timer3_Tick(sender As Object, e As EventArgs)
    '    'Keet the connection awake with each tick:

    '    If ConnectedToComNet = True Then
    '        Try
    '            If client.IsAlive() Then
    '                Message.Add(Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf)
    '                Timer3.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
    '            Else
    '                Message.Add(Format(Now, "HH:mm:ss") & " Connection Fault." & vbCrLf)
    '                Timer3.Interval = TimeSpan.FromMinutes(55).TotalMilliseconds '55 minute interval
    '            End If
    '        Catch ex As Exception
    '            Message.AddWarning(ex.Message & vbCrLf)
    '            'Set interval to five minutes - try again in five minutes:
    '            Timer3.Interval = TimeSpan.FromMinutes(5).TotalMilliseconds '5 minute interval
    '        End Try
    '    Else
    '        Message.Add(Format(Now, "HH:mm:ss") & " Not connected." & vbCrLf)
    '    End If
    'End Sub

    Private Sub ToolStripMenuItem1_EditWorkflowTabPage_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1_EditWorkflowTabPage.Click
        'Edit the Workflows Web Page:

        If WorkflowFileName = "" Then
            Message.AddWarning("No page to edit." & vbCrLf)
        Else
            Dim FormNo As Integer = OpenNewHtmlDisplayPage()
            HtmlDisplayFormList(FormNo).FileName = WorkflowFileName
            HtmlDisplayFormList(FormNo).OpenDocument
        End If

    End Sub

    Private Sub ToolStripMenuItem1_ShowStartPageInWorkflowTab_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1_ShowStartPageInWorkflowTab.Click
        'Show the Start Page in the Workflows Tab:
        OpenStartPage()

    End Sub

    Private Sub bgwComCheck_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwComCheck.DoWork
        'The communications check thread.
        While ConnectedToComNet
            Try
                If client.IsAlive() Then
                    'Message.Add(Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf) 'This produces the error: Cross thread operation not valid.
                    bgwComCheck.ReportProgress(1, Format(Now, "HH:mm:ss") & " Connection OK." & vbCrLf)
                Else
                    'Message.Add(Format(Now, "HH:mm:ss") & " Connection Fault." & vbCrLf) 'This produces the error: Cross thread operation not valid.
                    bgwComCheck.ReportProgress(1, Format(Now, "HH:mm:ss") & " Connection Fault.")
                End If
            Catch ex As Exception
                bgwComCheck.ReportProgress(1, "Error in bgeComCheck_DoWork!" & vbCrLf)
                bgwComCheck.ReportProgress(1, ex.Message & vbCrLf)
            End Try

            'System.Threading.Thread.Sleep(60000) 'Sleep time in milliseconds (60 seconds) - For testing only.
            'System.Threading.Thread.Sleep(3600000) 'Sleep time in milliseconds (60 minutes)
            System.Threading.Thread.Sleep(1800000) 'Sleep time in milliseconds (60 minutes)
        End While
    End Sub

    Private Sub bgwComCheck_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwComCheck.ProgressChanged
        Message.Add(e.UserState.ToString) 'Show the ComCheck message 
    End Sub

    Private Sub bgwSendMessage_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendMessage.DoWork
        'Send a message on a separate thread:
        Try
            If IsNothing(client) Then
                bgwSendMessage.ReportProgress(1, "No Connection available. Message not sent!")
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    bgwSendMessage.ReportProgress(1, "Connection state is faulted. Message not sent!")
                Else
                    Dim SendMessageParams As clsSendMessageParams = e.Argument
                    client.SendMessage(SendMessageParams.ProjectNetworkName, SendMessageParams.ConnectionName, SendMessageParams.Message)
                End If
            End If
        Catch ex As Exception
            bgwSendMessage.ReportProgress(1, ex.Message)
        End Try
    End Sub

    Private Sub bgwSendMessage_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSendMessage.ProgressChanged
        'Display an error message:
        Message.AddWarning("Send Message error: " & e.UserState.ToString & vbCrLf) 'Show the bgwSendMessage message 
    End Sub

    Private Sub bgwSendMessageAlt_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendMessageAlt.DoWork
        'Alternative SendMessage background worker - used to send a message while instructions are being processed. 
        'Send a message on a separate thread
        Try
            If IsNothing(client) Then
                bgwSendMessageAlt.ReportProgress(1, "No Connection available. Message not sent!")
            Else
                If client.State = ServiceModel.CommunicationState.Faulted Then
                    bgwSendMessageAlt.ReportProgress(1, "Connection state is faulted. Message not sent!")
                Else
                    Dim SendMessageParamsAlt As clsSendMessageParams = e.Argument
                    client.SendMessage(SendMessageParamsAlt.ProjectNetworkName, SendMessageParamsAlt.ConnectionName, SendMessageParamsAlt.Message)
                End If
            End If
        Catch ex As Exception
            bgwSendMessageAlt.ReportProgress(1, ex.Message)
        End Try
    End Sub

    Private Sub bgwSendMessageAlt_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSendMessageAlt.ProgressChanged
        'Display an error message:
        Message.AddWarning("Send Message error: " & e.UserState.ToString & vbCrLf) 'Show the bgwSendMessageAlt message 
    End Sub

    Private Sub XMsg_ErrorMsg(ErrMsg As String) Handles XMsg.ErrorMsg
        Message.AddWarning(ErrMsg & vbCrLf)
    End Sub

    Private Sub XMsgLocal_Instruction(Info As String, Locn As String) Handles XMsgLocal.Instruction

    End Sub

    Private Sub Message_ShowXMessagesChanged(Show As Boolean) Handles Message.ShowXMessagesChanged
        ShowXMessages = Show
    End Sub

    Private Sub Message_ShowSysMessagesChanged(Show As Boolean) Handles Message.ShowSysMessagesChanged
        ShowSysMessages = Show
    End Sub

    Private Sub dgvMeasuredData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMeasuredData.CellContentClick

    End Sub
End Class 'Main

'Conversion factors: FactorB and FactorC. (Used to convert between values measured in different EPSG units.)
Public Class ConversionFactors
    'Conversion factors: FactorB and FactorC.
    'The factors are used to convert from a distance value in a unit into the corresponding value in standard (metre) units.
    'The standard distance unit is metre.
    'Value in metres is input value * FactorB / FactorC

    Private _factorB As Double
    Property FactorB As Double
        Get
            Return _factorB
        End Get
        Set(value As Double)
            _factorB = value
        End Set
    End Property

    Private _factorC As Double
    Property FactorC As Double
        Get
            Return _factorC
        End Get
        Set(value As Double)
            _factorC = value
        End Set
    End Property

End Class

'Public Module CopyPasteFunctions
'    Public Function GetTopLeftSelectedCell(ByVal cells As DataGridViewSelectedCellCollection) As DataGridViewCell
'        If Not IsNothing(cells) AndAlso cells.Count > 0 Then
'            Dim cellList = (From c In cells.Cast(Of DataGridViewCell)()
'                            Order By c.RowIndex, c.ColumnIndex
'                            Select c).ToList

'            Return cellList(0)
'        End If

'        Return Nothing
'    End Function
'End Module

Public Class clsSendMessageParams
    'Parameters used when sending a message using the Message Service.
    Public ProjectNetworkName As String
    Public ConnectionName As String
    Public Message As String
End Class
