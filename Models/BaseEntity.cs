using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using SchedulingApplication.Utilities;

namespace SchedulingApplication.Models
{
    /// <summary>
    /// Base class for all entities with common audit fields
    /// </summary>

    public abstract class BaseEntity : INotifyPropertyChanged
    {
        private DateTime _createDate;
        private string _createdBy;
        private DateTime _lastUpdate;
        private string _lastUpdateBy;

        [Column("createDate")]
        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                _createDate = value;
                OnPropertyChanged();
            }
        }

        [StringLength(40)]
        [Column("createdBy")]
        public string CreatedBy
        {
            get { return _createdBy; }
            set
            {
                _createdBy = value;
                OnPropertyChanged();
            }
        }

        [Column("lastUpdate")]
        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set
            {
                _lastUpdate = value;
                OnPropertyChanged();
            }
        }

        [StringLength(40)]
        [Column("lastUpdateBy")]
        public string LastUpdateBy
        {
            get { return _lastUpdateBy; }
            set
            {
                _lastUpdateBy = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the formatted creation date/time in the user's local timezone
        /// </summary>
        [NotMapped]
        public string LocalCreateDate
        {
            get { return TimeZoneHelper.UtcToLocal(CreateDate).ToString("MM/dd/yyyy hh:mm tt"); }
        }

        /// <summary>
        /// Gets the formatted last update date/time in the user's local timezone
        /// </summary>
        [NotMapped]
        public string LocalLastUpdate
        {
            get { return TimeZoneHelper.UtcToLocal(LastUpdate).ToString("MM/dd/yyyy hh:mm tt"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
