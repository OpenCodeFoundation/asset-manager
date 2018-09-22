using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities
{
    public class Settings: Entity
    {
        public int UserId { get; set; }
        public int PerPage { get; set; }

        public string SiteName { get; set; }

        public int QrCode { get; set; }

        public string QrText { get; set; }

        public int DisplayAssetName { get; set; }

        public int DisplayCheckoutDate { get; set; }

        public int DisplayEol { get; set; }

        public int AutoIncrementAsset { get; set; }

        public string AutoIncrementPrefix { get; set; }

        public bool LoadRemote { get; set; }

        public string Logo { get; set; }

        public string HeaderColor { get; set; }

        public string AlertEmail { get; set; }

        public bool AlertEnable { get; set; }

        public string DefaultEulaText { get; set; }

        public string BarcodeType { get; set; }

        public string SlackEndPoint { get; set; }

        public string SlackChannel { get; set; }

        public string SlackBotName { get; set; }

        public string DefaultCurrency { get; set; }

        public string CustomCss { get; set; }

        public bool Brand { get; set; }

        public string LdapEnabled { get; set; }

        public string ladpServer { get; set; }

        public string LadpUName { get; set; }

        public string LdapPass { get; set; }

        public string LadpBaseDn { get; set; }

        public string LdapFilter { get; set; }

        public string LdapUserNameField { get; set; }

        public string ldapLNameField { get; set; }

        public string ldapFNameField { get; set; }

        public string ldapAuthFilterQuery { get; set; }

        public int ldapVersion { get; set; }

        public string ldapActiveFlag { get; set; }
        public string ldapEmpNum { get; set; }
        public string ldapEmail { get; set; }

        public bool FullMultipleCompanySupport { get; set; }

        public bool LdapCertIgnore { get; set; }

        public string Locale { get; set; }

        public bool LabelsPerPage { get; set; }

        public decimal LabelsWidth { get; set; }

        public decimal LabelsHeight { get; set; }
        public decimal LabelsPMarginLeft { get; set; }
        public decimal LabelsPMarginRight { get; set; }

        public decimal LabelsPMarginTop { get; set; }

        public decimal LabelsPMarginBottom { get; set; }

        public decimal LabelsDesplayPGutter { get; set; }
        public decimal LabelsDisplaySGutter { get; set; }
        public decimal LabelsFontSize { get; set; }

        public decimal LabelsPagewidth { get; set; }

        public decimal LabelsPageHeight { get; set; }

        public decimal LabelsDisplayName { get; set; }

        public decimal LabelsDisplaySerial { get; set; }

        public decimal LabelsDisplayTag { get; set; }

        public string AltBarcode { get; set; }

        public bool AltBarcodeEnabled { get; set; }

        public decimal AlertInterval { get; set; }

        public decimal AlertThreshold { get; set; }

        public string EmailDomain { get; set; }

        public string EmailFormat { get; set; }

        public string UserNameFormat { get; set; }

        public bool IsAd { get; set; }

        public string AdDomain { get; set; }

        public string LdapPort { get; set; }

        public bool LdapTls { get; set; }

        public int ZeroFillCount { get; set; }

        public bool LdapPwSync { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool RequireAcceptSignature { get; set; }

        public string DateDisplayFormat { get; set; }

        public string TimeDisplayFormat { get; set; }

        public long NextAutoTagBase { get; set; }

        public string LoginNote { get; set; }

        public int ThumbnailMaxH { get; set; }

        public bool PwdSecureUnCommon { get; set; }
        public string PwdSecureComplexity { get; set; }

        public int PwdSecureMin { get; set; }

        public int AuditInterval { get; set; }

        public int AuditWarningDays { get; set; }

        public bool ShowUrlInEmails { get; set; }
        public bool CustomForgotPassUrl { get; set; }

        public bool ShowAlertsInMenu { get; set; }
        public bool LabelsDisplayCompanyName { get; set; }
    }
}
