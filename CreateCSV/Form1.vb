﻿Imports System.IO
Imports System.Text
Imports System.Collections

Public Class Form1
#Region "定数"
#End Region
#Region "変数"

#End Region


#Region "もとになるCSVファイルD&D"
    ''' <summary>
    ''' もとになるCSVファイルドラッグアンドドロップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TargetFullPath_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles TargetFullPath.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
#End Region

#Region "もとになるCSVファイルD&D"
    ''' <summary>
    ''' もとになるCSVファイルドラッグアンドドロップ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TargetFullPath_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TargetFullPath.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            ' ドラッグされたファイルに対する処理を行う
            If files.Length > 1 Then
                'メッセージボックスを表示する
                Class1.ShowMessageBox("ファイルは1ファイルしか取り込めません", "Error")

                '問題がある箇所背景赤に変更
                TargetFullPath.BackColor = Color.Red

                Exit Sub
            End If

            ' ファイルのパスを使用して必要な処理を実行する
            TargetFullPath.Text += files(0) & Environment.NewLine

        End If
    End Sub

#End Region

#Region "対象CSVファイルの参照ボタン押下"
    ''' <summary>
    ''' 対象csvファイルの参照ボタンを押したら
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TargetReButtonf_Click(sender As Object, e As EventArgs) Handles TargetRef.Click
        ' ファイルダイアログを開く変数を作成しインスタンス化
        Dim Dialog As New OpenFileDialog()
        ' 各パラメータを設定していきます
        With Dialog
            ' 最初に表示されるデフォルトのフォルダ名を設定
            .InitialDirectory = "C:\Users\chopp\OneDrive\デスクトップ\CSV分割"
            ' 読込むファイルの種類を設定
            .Filter = "csvファイル" & "|" & "*.csv"
            ' ファイルダイアログのタイトルを設定
            .Title = "読み込みたいファイルを選択してください。"
            ' ファイルダイアログを閉じる前に現在のフォルダを復元するかしないか
            .RestoreDirectory = True
        End With

        If Dialog.ShowDialog() = DialogResult.OK Then
            TargetFullPath.Text = Dialog.FileName
        End If

    End Sub
#End Region

#Region "出力先フォルダの参照ボタン押下"
    ''' <summary>
    ''' 出力先フォルダの参照ボタンを押したら
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OutputRefButton_Click(sender As Object, e As EventArgs) Handles OutputRef.Click
        Dim Dialog As New FolderBrowserDialog()

        ' 各パラメータを設定する
        With Dialog
            ' 最初に表示されるデフォルトのフォルダ名を設定
            .SelectedPath = "C:\Users\chopp\OneDrive\デスクトップ\CSV分割"
            ' ファイルダイアログのタイトルを設定
            .Description = "出力先のフォルダを選択してください。"
            .ShowNewFolderButton = True
        End With

        If Dialog.ShowDialog() = DialogResult.OK Then
            ' テキストボックスに入力する
            OutputPath.Text = Dialog.SelectedPath & "\"
        End If

    End Sub
#End Region

#Region "CSV作成"
    ''' <summary>
    ''' CSV作成ボタンを押したら
    ''' </summary>
    Private Sub SplitButton_Click() Handles Split.Click
        Dim strTargetFullPath As String = TargetFullPath.Text   'もととなるcsvファイルフルパス
        Dim strCreateRow As Integer = CreateRow.Text            '作成する行
        Dim strHeaderRow As Integer = HeaderRow.Text            'ヘッダの行数
        Dim strOutputPath As String = OutputPath.Text           '出力先パス

        Dim strFileName As String           'ファイル名
        Dim strOutputFullPath As String     '出力先フルパス ※作成するファイル名は末尾に作成行数を記載する
        Dim lines As String()               'ファイルの中身行を格納

        Dim startTime As DateTime           ' 開始時刻
        Dim endTime As DateTime             ' 終了時刻

        Try
            '入力チェック
            If Not File.Exists(strTargetFullPath) Then
                Class1.ShowMessageBox("対象ファイルのパスがおかしいです。ご確認ください", "Error")
                TargetFullPath.BackColor = Color.Red
                Exit Sub
            End If

            '変数設定
            strFileName = Path.GetFileName(strTargetFullPath)             'ファイル名
            strOutputFullPath = strOutputPath & strFileName.Insert(strFileName.Length - 4, "_" & strCreateRow.ToString)  '出力先フルパス ※作成するファイル名は末尾に作成行数を記載する
            lines = File.ReadAllLines(strTargetFullPath, Encoding.UTF8) 'ファイルの中身行を格納

            startTime = DateTime.Now
            Logger.Log("～" & strCreateRow.ToString & "件のCSVファイルを作成します～")
            Logger.Log("【開始時間】" & startTime.ToString)
            Cursor.Current = Cursors.WaitCursor

            Using writer As New StreamWriter(strOutputFullPath, False, Encoding.UTF8)
                'ヘッダの書き込み
                For i As Integer = 0 To strHeaderRow - 1
                    writer.WriteLine(lines(i))
                Next

                'データ書き込み
                MakeDataRow(strHeaderRow, strCreateRow, strOutputFullPath, lines, writer)
            End Using

            '処理成功したら初期状態に戻す
            Init()

            'メッセージボックスを表示する
            Cursor.Current = Cursors.Default
            Me.TopMost = True       '他のアプリ含めて最前面に表示する
            'MessageBox.Show(Me, "作成完了しました", "処理結果", MessageBoxButtons.OK, MessageBoxIcon.None)
            Class1.ShowMessageBox("作成完了しました", "Result")
            'OK押下されたら戻す
            Me.TopMost = False

            endTime = DateTime.Now
            Logger.Log("【終了時間】" & endTime.ToString)

            'Dim ts As TimeSpan
            'Logger.Log("【処理時間】" & (TimeSpan.TryParseExact((endTime - startTime).ToString(), "'h'時間'm'分's'秒'fff", Nothing, ts)))
            Logger.Log("【処理時間】" & (endTime - startTime).ToString())

            '出力先のフォルダを開く
            'System.Diagnostics.Process.Start(strOutputPath)
            '出力先したファイルを開く 上記は残すか考え中
            If strCreateRow + 2 < 100000 Then                       '作成した行数が10万件以下の場合
                Process.Start(strOutputFullPath)                    'Excelで開く
            Else
                Process.Start("EmEditor.exe", strOutputFullPath)    '大量件数の為EmEditorで開く
            End If

        Catch ex As ArithmeticException
            Class1.ShowMessageBox("処理に失敗しました。ご確認ください", "Error")
        End Try
    End Sub
#End Region

#Region "データ作成"
    ''' <summary>
    ''' データ作成
    ''' <param name="strHeaderRow"></param>
    ''' <param name="strCreateRow"></param>
    ''' <param name="strOutputFullPath"></param>
    ''' <param name="lines"></param>
    ''' <param name="writer"></param>
    ''' </summary>
    Private Sub MakeDataRow(strHeaderRow As Integer, strCreateRow As Integer, strOutputFullPath As String, lines As String(), writer As StreamWriter)
        Dim intBatchSize As Integer = 100000 ' バッチサイズ
        intBatchSize = If(strCreateRow <= intBatchSize, strCreateRow, intBatchSize) ' バッチサイズ

        'チェックがついていなかったらそのまま内容複製
        If ChangeRowFlg.Checked = False Then
            '行の書き込み
            For i As Integer = strHeaderRow To strCreateRow
                writer.WriteLine(lines(strHeaderRow))
            Next
        Else            'チェックがついていたら末尾に数字をつける
            Dim columns As String()
            Dim duplicatedData As String
            Dim dataIndex As String

            '行の書き込み
            columns = lines(strHeaderRow).Split(","c) ' 列ごとにデータを分割

            '大量データ対策の為一定の行数毎
            For batchIndex As Integer = 0 To Math.Ceiling(strCreateRow / intBatchSize) - 1
                Using memoryStream As New MemoryStream()
                    Using streamWriter As New StreamWriter(memoryStream)
                        '行毎
                        For i As Integer = 1 To intBatchSize
                            duplicatedData = Nothing              '行を読み込むごとに初期化
                            dataIndex = If(batchIndex = 0, i, batchIndex * intBatchSize + i)

                            '列毎
                            For j As Integer = 0 To columns.Length - 1
                                duplicatedData += columns(j).Trim() & dataIndex.ToString()  'データの末尾に行番号を追加して内容を変更する

                                '最後の列でなければ、カンマを追加
                                If j <> columns.Length - 1 Then
                                    duplicatedData += ","
                                End If
                            Next

                            '処理時間懸念の為、毎行毎にファイル書き込みを行う
                            writer.WriteLine(duplicatedData.ToArray)
                        Next

                        ' メモリストリームの内容をファイルに書き込む
                        streamWriter.Flush()
                        memoryStream.Seek(0, SeekOrigin.Begin)
                        memoryStream.CopyTo(writer.BaseStream)
                    End Using
                End Using
            Next
        End If
    End Sub
#End Region

#Region "初期状態に戻す"
    ''' <summary>
    ''' 初期状態に戻す
    ''' </summary>
    Private Sub Init()
        CreateRow.BackColor = Color.White
    End Sub
#End Region
End Class
