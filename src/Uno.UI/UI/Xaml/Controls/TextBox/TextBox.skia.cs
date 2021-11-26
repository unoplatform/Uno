using Windows.UI.Xaml.Media;

namespace Windows.UI.Xaml.Controls
{
	public partial class TextBox
	{
		internal TextBoxView TextBoxView { get; private set; }
		
		internal ContentControl ContentElement => _contentElement;

		partial void OnForegroundColorChangedPartial(Brush newValue) => TextBoxView?.OnForegroundChanged(newValue);

		partial void OnMaxLengthChangedPartial(DependencyPropertyChangedEventArgs e) => TextBoxView?.UpdateMaxLength();

		private void UpdateTextBoxView()
		{
			TextBoxView ??= new TextBoxView(this);
			if (ContentElement != null && ContentElement.Content != TextBoxView.DisplayBlock)
			{
				ContentElement.Content = TextBoxView.DisplayBlock;
			}
		}

		partial void OnFocusStateChangedPartial(FocusState focusState) => TextBoxView?.OnFocusStateChanged(focusState);

		partial void SelectPartial(int start, int length)
		{
			TextBoxView?.Select(start, length);
		}

		partial void SelectAllPartial() => Select(0, Text.Length);

		public int SelectionStart
		{
			get => TextBoxView?.GetSelectionStart() ?? 0;
			set => Select(start: value, length: SelectionLength);
		}

		public int SelectionLength
		{
			get => TextBoxView?.GetSelectionLength() ?? 0;
			set => Select(SelectionStart, value);
		}


		protected void SetIsPassword(bool isPassword) => TextBoxView?.SetIsPassword(isPassword);
	}
}
