Public Class Form1
    'Declare variables for patient details and medical advice

    Dim patientName As String
    Dim patientSurname As String
    Dim patientContact As String
    Dim patientEmail As String
    Dim patientLocation As String
    Dim selectedHealthIssue As String
    Dim CareLevelText As String
    Dim recommendation As String
    Dim clinicContact As String
    Dim clinicAddress As String
    Dim doctorContact As String
    Dim doctorsAddress As String
    Dim hospitalContact As String
    Dim emergencyAddress As String
    Dim totalPrice As Decimal

    Private Sub Assign()
        ' Assign textbox and combobox values to variables
        patientName = txtPatientName.Text
        patientSurname = txtSurname.Text
        patientContact = txtPhoneNumber.Text
        patientEmail = txtEmail.Text
        patientLocation = txtLocation.Text
        selectedHealthIssue = cmbHealthIssue.Text
    End Sub

    Private Function ValidateInputs() As Boolean
        ' Validate required inputs (name, phone,Location, HealthIssue selection)

        If String.IsNullOrEmpty(txtPatientName.Text) OrElse String.IsNullOrEmpty(cmbHealthIssue.Text) Then
            MessageBox.Show("Please enter patient details and select a health issue.", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub HealthIssue()
        ' Populate HealthIssue combobox with predefined options
        cmbHealthIssue.Items.Clear()
        cmbHealthIssue.Items.Add("Mild Fever")
        cmbHealthIssue.Items.Add("Sore Throat")
        cmbHealthIssue.Items.Add("Back Pain")
        cmbHealthIssue.Items.Add("High Fever")
        cmbHealthIssue.Items.Add("Kidney Stones")
        cmbHealthIssue.Items.Add("Severe Headach")
        cmbHealthIssue.Items.Add("Broken Bone")
        cmbHealthIssue.Items.Add("Short Breath")
        cmbHealthIssue.Items.Add("Severe Bleeding")

        cmbHealthIssue.SelectedIndex = 0
    End Sub

    Private Sub SymptomsResult()
        ' Determines medical referral based on selected symptom using Select Case
        Select Case selectedHealthIssue
            ' Mild cases → Clinic
            Case "Mild Fever", "Sore Throat", "Back Pain"
                CareLevelText = "Clinic"
                recommendation = "Please visit the Overport Medical Clinic."
                clinicContact = "031 209 3746"
                clinicAddress = " Mazisi Kunene Rd, Overport"
                totalPrice = 300
                lblCareLevel.ForeColor = Color.Green

                ' Moderate cases → Doctor
            Case "High Fever", "Kidney Stones", "Severe Headach"
                CareLevelText = "Doctor"
                recommendation = "Please see Dr AA Solwa Medical Practice."
                doctorContact = " 031 303 8581"
                doctorsAddress = " Berea, Durban"
                totalPrice = 500
                lblCareLevel.ForeColor = Color.Orange

               ' Emergency cases → Hospital
            Case "Broken Bone", "Short Breath", "Severe Bleeding"
                CareLevelText = "Emergency"
                recommendation = "Please go to Netcare ST Augustine's Hospital immediately."
                hospitalContact = "031 268 5000"
                emergencyAddress = "107 J.B Marks Road Bulwer Berea, Durban,4001"
                totalPrice = 800
                lblCareLevel.ForeColor = Color.Red
            Case Else
                lblCareLevel.Text = CareLevelText
        End Select
    End Sub

    Private Sub Output()
        ' Display all patient information and recommendations in listbox
        lstOutput.Items.Clear()
        lstOutput.Items.Add("===== MediCare_Assist====")
        lstOutput.Items.Add("================================")
        lstOutput.Items.Add("Name: " & patientName)
        lstOutput.Items.Add("Surname: " & patientSurname)
        lstOutput.Items.Add("Contact: " & patientContact)
        lstOutput.Items.Add("Email: " & patientEmail)
        lstOutput.Items.Add("Location: " & patientLocation)
        lstOutput.Items.Add("Symptom: " & selectedHealthIssue)
        lstOutput.Items.Add("Status: " & CareLevelText)
        lstOutput.Items.Add("Advice: " & recommendation)

        ' Show clinic details if applicable
        If clinicContact <> "" Then
            lstOutput.Items.Add("Clinic Contact: " & clinicContact)
            lstOutput.Items.Add("Clinic Address: " & clinicAddress)
        End If
        ' Show doctor details if applicable
        If doctorContact <> "" Then
            lstOutput.Items.Add("Doctor Contact: " & doctorContact)
            lstOutput.Items.Add("Doctor Address: " & doctorsAddress)
        End If
        ' Show hospital details if applicable
        If hospitalContact <> "" Then
            lstOutput.Items.Add("Hospital Contact: " & hospitalContact)
            lstOutput.Items.Add("Emergency Address: " & emergencyAddress)
        End If
        lstOutput.Items.Add("Total Price: R" & totalPrice.ToString("0.00"))
    End Sub

    Private Sub Reset()
        ' Clear all input fields and output list
        txtPatientName.Clear()
        txtSurname.Clear()
        txtPhoneNumber.Clear()
        txtEmail.Clear()
        txtLocation.Clear()
        cmbHealthIssue.SelectedIndex = 0
        lstOutput.Items.Clear()
    End Sub
    Private Sub BtnCheck_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheck.Click
        'Check button click: validate, assign, process, and display results
        If Not ValidateInputs() Then Exit Sub

        Assign()
        SymptomsResult()
        lblCareLevel.Text = CareLevelText
        Output()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'Resets form for new patient
        Reset()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        ' Handles Exit button click: Closes the application
        Me.Close()
    End Sub

End Class




