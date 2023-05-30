<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Split = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TargetFullPath = New System.Windows.Forms.TextBox()
        Me.CreateRow = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OutputPath = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TargetRef = New System.Windows.Forms.Button()
        Me.OutputRef = New System.Windows.Forms.Button()
        Me.HeaderRow = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChangeRowFlg = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Split
        '
        Me.Split.Font = New System.Drawing.Font("MS UI Gothic", 18.0!)
        Me.Split.Location = New System.Drawing.Point(336, 307)
        Me.Split.Name = "Split"
        Me.Split.Size = New System.Drawing.Size(120, 49)
        Me.Split.TabIndex = 0
        Me.Split.Text = "CSV作成"
        Me.Split.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(177, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ベースとなるファイルフルパス"
        '
        'TargetFullPath
        '
        Me.TargetFullPath.AllowDrop = True
        Me.TargetFullPath.Location = New System.Drawing.Point(318, 45)
        Me.TargetFullPath.Name = "TargetFullPath"
        Me.TargetFullPath.Size = New System.Drawing.Size(288, 19)
        Me.TargetFullPath.TabIndex = 2
        Me.TargetFullPath.Text = "D&Dもできます"
        Me.TargetFullPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CreateRow
        '
        Me.CreateRow.Location = New System.Drawing.Point(318, 103)
        Me.CreateRow.Name = "CreateRow"
        Me.CreateRow.Size = New System.Drawing.Size(288, 19)
        Me.CreateRow.TabIndex = 4
        Me.CreateRow.Text = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(177, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "何行作成しますか？"
        '
        'OutputPath
        '
        Me.OutputPath.Location = New System.Drawing.Point(318, 218)
        Me.OutputPath.Name = "OutputPath"
        Me.OutputPath.Size = New System.Drawing.Size(288, 19)
        Me.OutputPath.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(177, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "出力先"
        '
        'TargetRef
        '
        Me.TargetRef.Location = New System.Drawing.Point(632, 43)
        Me.TargetRef.Name = "TargetRef"
        Me.TargetRef.Size = New System.Drawing.Size(75, 23)
        Me.TargetRef.TabIndex = 9
        Me.TargetRef.Text = "参照"
        Me.TargetRef.UseVisualStyleBackColor = True
        '
        'OutputRef
        '
        Me.OutputRef.Location = New System.Drawing.Point(632, 216)
        Me.OutputRef.Name = "OutputRef"
        Me.OutputRef.Size = New System.Drawing.Size(75, 23)
        Me.OutputRef.TabIndex = 10
        Me.OutputRef.Text = "参照"
        Me.OutputRef.UseVisualStyleBackColor = True
        '
        'HeaderRow
        '
        Me.HeaderRow.Location = New System.Drawing.Point(318, 159)
        Me.HeaderRow.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.HeaderRow.Name = "HeaderRow"
        Me.HeaderRow.Size = New System.Drawing.Size(288, 19)
        Me.HeaderRow.TabIndex = 15
        Me.HeaderRow.Text = "2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(177, 162)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 12)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "対象のヘッダは何行ですか？"
        '
        'ChangeRowFlg
        '
        Me.ChangeRowFlg.AutoSize = True
        Me.ChangeRowFlg.Location = New System.Drawing.Point(577, 263)
        Me.ChangeRowFlg.Name = "ChangeRowFlg"
        Me.ChangeRowFlg.Size = New System.Drawing.Size(134, 16)
        Me.ChangeRowFlg.TabIndex = 16
        Me.ChangeRowFlg.Text = "毎行内容変更したいか"
        Me.ChangeRowFlg.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ChangeRowFlg)
        Me.Controls.Add(Me.HeaderRow)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.OutputRef)
        Me.Controls.Add(Me.TargetRef)
        Me.Controls.Add(Me.OutputPath)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CreateRow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TargetFullPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Split)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Split As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TargetFullPath As TextBox
    Friend WithEvents CreateRow As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents OutputPath As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TargetRef As Button
    Friend WithEvents OutputRef As Button
    Friend WithEvents HeaderRow As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ChangeRowFlg As CheckBox
End Class
