
Public Class Form1
    'Declare variables
    Dim patientName As String
    Dim patientSurname As String
    Dim Age As Integer


    Private Sub assign()
        ' Subroutine to read name and surname from textboxes and store them in variables
        patientName = txtName.Text
        patientSurname = txtSurname.Text
        Age = CInt(txtAge.Text)
    End Sub

    Private Function SelectedGender(ByVal isMale As Boolean, ByVal isFemale As Boolean, ByVal isOther As Boolean) As String
        ' Returns the selected gender as a string based on three Boolean parameters.
        If isMale Then Return "Male"
        If isFemale Then Return "Female"
        If isOther Then Return "Other"
        Return "" ' No gender selected
    End Function
    Private Function GetTreatments() As String
        ' Function that builds a string of all selected treatments (checkboxes)
        Dim result As String = ""
        If chkBloodTest.Checked Then
            result &= "Blood Test "
        End If
        If chkCounseling.Checked Then
            result &= "Counselling "
        End If
        If chkMedication.Checked Then
            result &= "Medication "
        End If
        If chkPhysiotherapy.Checked Then
            result &= "Physiotherapy"
        End If


        Return result
    End Function

    Private Function ValidateInput(ByVal name As String, ByVal surname As String) As Boolean
        ' Validation function: checks if required fields are filled
        If String.IsNullOrEmpty(txtName.Text) OrElse String.IsNullOrEmpty(txtSurname.Text) OrElse String.IsNullOrEmpty(txtAge.Text) Then
            MessageBox.Show("Please enter patient details.", "Required fields",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub Reset()
        ' Subroutine to clear all inputs and reset the form
        txtSurname.Text = ""
        txtName.Text = ""
        txtAge.Text = ""

        radMale.Checked = False
        radFemale.Checked = False
        radOther.Checked = False

        chkMedication.Checked = False
        chkPhysiotherapy.Checked = False
        chkCounseling.Checked = False
        chkBloodTest.Checked = False
        lblOutput.Text = ""
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Button click: Submit the patient registration and treatment plan
        If Not ValidateInput(txtName.Text, txtSurname.Text) Then Exit Sub
        assign()
        Dim gender As String = SelectedGender(radMale.Checked, radFemale.Checked, radOther.Checked)
        Dim treatments As String = GetTreatments()


        ' Display on label
        lblOutput.Text = "Name: " & patientName & vbCrLf &
                 "Surname: " & patientSurname & vbCrLf &
                 "Age: " & Age & vbCrLf &
                 "Gender: " & gender & vbCrLf &
                 "Treatments: " & treatments
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear all inputs
        Reset()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Exit the application
        Me.Close()
    End Sub
End Class
