using MudBlazor;

namespace Equality.Client
{
    public abstract class BaseTheme : MudTheme
    {
        protected BaseTheme()
        {
            LayoutProperties.DefaultBorderRadius = "5px";
            Typography.Body1.FontFamily =
                Typography.Body2.FontFamily =
                    Typography.Button.FontFamily =
                        Typography.H1.FontFamily =
                            Typography.H2.FontFamily =
                                Typography.H3.FontFamily =
                                    Typography.H4.FontFamily =
                                        Typography.H5.FontFamily =
                                            Typography.H6.FontFamily =
                                                Typography.Subtitle1.FontFamily =
                                                    Typography.Subtitle2.FontFamily =
                                                        Typography.Overline.FontFamily =
                                                            Typography.Caption.FontFamily =
                                                                Typography.Default.FontFamily = new[] { "Inter" };
        }
    }
}