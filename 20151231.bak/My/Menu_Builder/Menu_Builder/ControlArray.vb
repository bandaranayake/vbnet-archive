Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms

Public MustInherit Class ControlArray(Of TControl As Control)
    Inherits Component
    Implements IList, IList(Of TControl)

#Region " Fields "

    Private items As New List(Of TControl)
    Private _syncRoot As Object

#End Region 'Fields

#Region " Properties "

    <Browsable(False)>
    Public ReadOnly Property Count As Integer Implements ICollection.Count, ICollection(Of TControl).Count
        Get
            Return Me.items.Count
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property IsFixedSize As Boolean Implements IList.IsFixedSize
        Get
            Return False
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property IsReadOnly As Boolean Implements IList.IsReadOnly, ICollection(Of TControl).IsReadOnly
        Get
            Return False
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property IsSynchronized As Boolean Implements ICollection.IsSynchronized
        Get
            Return False
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the item at a specific index.
    ''' </summary>
    ''' <param name="index">
    ''' The index of the item to get or set.
    ''' </param>
    ''' <value>
    ''' The item at the specified index.
    ''' </value>
    Default Public Overridable Property Item(ByVal index As Integer) As TControl Implements IList(Of TControl).Item
        Get
            Return Me.items(index)
        End Get
        Set(ByVal value As TControl)
            Me.items(index) = value
        End Set
    End Property

    Private Property ItemInternal(ByVal index As Integer) As Object Implements IList.Item
        Get
            Return Me.Item(index)
        End Get
        Set(ByVal value As Object)
            Me.Item(index) = DirectCast(value, TControl)
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property SyncRoot As Object Implements ICollection.SyncRoot
        Get
            If Me._syncRoot Is Nothing Then
                Me._syncRoot = New Object
            End If

            Return Me._syncRoot
        End Get
    End Property

#End Region 'Properties

#Region " Methods "

    Public Function GetIndex(ByVal control As TControl) As Integer?
        Return If(Me.Contains(control),
                  Me.IndexOf(control),
                  DirectCast(Nothing, Integer?))
    End Function

    Public Overridable Sub SetIndex(ByVal control As TControl, ByVal index As Integer?)
        If Not index.Equals(Me.GetIndex(control)) Then
            'The control is either being moved to a different index or  removed altogether, so remove it from its current index.
            Me.Remove(control)
        End If

        If index.HasValue Then
            'Insert the control at its new index, or to the end of the list if the index is invalid.
            Me.Insert(Math.Min(index.Value,
                               Me.Count),
                      control)
        End If
    End Sub

#Region " IEnumerable, ICollection and IList Methods "

    Public Overridable Sub Add(ByVal item As TControl) Implements ICollection(Of TControl).Add
        Me.items.Add(item)
    End Sub

    Private Function AddInternal(ByVal value As Object) As Integer Implements IList.Add
        Dim control = DirectCast(value, TControl)

        Me.Add(control)

        Return Me.IndexOf(control)
    End Function

    Public Overridable Sub Clear() Implements IList.Clear, ICollection(Of TControl).Clear
        Me.items.Clear()
    End Sub

    Public Function Contains(ByVal item As TControl) As Boolean Implements ICollection(Of TControl).Contains
        Return Me.items.Contains(item)
    End Function

    Private Function ContainsInternal(ByVal value As Object) As Boolean Implements IList.Contains
        Return Me.Contains(DirectCast(value, TControl))
    End Function

    Public Sub CopyTo(ByVal array() As TControl, ByVal arrayIndex As Integer) Implements ICollection(Of TControl).CopyTo
        Me.items.CopyTo(array, arrayIndex)
    End Sub

    Public Sub CopyToInternal(ByVal array As System.Array, ByVal index As Integer) Implements ICollection.CopyTo
        Me.CopyTo(DirectCast(array, TControl()), index)
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of TControl) Implements IEnumerable(Of TControl).GetEnumerator
        Return Me.items.GetEnumerator()
    End Function

    Private Function GetEnumeratorInternal() As IEnumerator Implements IEnumerable.GetEnumerator
        Return Me.GetEnumerator()
    End Function

    Public Function IndexOf(ByVal item As TControl) As Integer Implements IList(Of TControl).IndexOf
        Return Me.items.IndexOf(item)
    End Function

    Private Function IndexOfInternal(ByVal value As Object) As Integer Implements IList.IndexOf
        Return Me.IndexOf(DirectCast(value, TControl))
    End Function

    Public Overridable Sub Insert(ByVal index As Integer, ByVal item As TControl) Implements IList(Of TControl).Insert
        Me.items.Insert(index, item)
    End Sub

    Private Sub InsertInternal(ByVal index As Integer, ByVal value As Object) Implements IList.Insert
        Me.Insert(index, DirectCast(value, TControl))
    End Sub

    Public Overridable Function Remove(ByVal item As TControl) As Boolean Implements ICollection(Of TControl).Remove
        Return Me.items.Remove(item)
    End Function

    Private Sub RemoveInternal(ByVal value As Object) Implements IList.Remove
        Me.Remove(DirectCast(value, TControl))
    End Sub

    Public Overridable Sub RemoveAt(ByVal index As Integer) Implements IList.RemoveAt, IList(Of TControl).RemoveAt
        Me.items.RemoveAt(index)
    End Sub

#End Region

#End Region

End Class

<ProvideProperty("Index", GetType(vButton))>
Public Class ButtonArray
    Inherits ControlArray(Of vButton)
End Class

<ProvideProperty("Index", GetType(vLabel))>
Public Class LabelArray
    Inherits ControlArray(Of vLabel)
End Class

<ProvideProperty("Index", GetType(vLinkLabel))>
Public Class LinkLabelArray
    Inherits ControlArray(Of vLinkLabel)

End Class

