using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IDInfoRead
{
    public class PostData
    {
        #region 字段
        private string _localmac;
        private string _name;
        private string _sex;
        private string _nation;
        private string _birthday;
        private string _number;
        private string _address;
        private string _issue;
        private string _enable_time;
        private string _photo_id;

        #endregion

        #region 属性

        public string localmac
        {
            get
            {
                return _localmac;
            }

            set
            {
                _localmac = value;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string sex
        {
            get
            {
                return _sex;
            }

            set
            {
                _sex = value;
            }
        }

        public string nation
        {
            get
            {
                return _nation;
            }

            set
            {
                _nation = value;
            }
        }

        public string birthday
        {
            get
            {
                return _birthday;
            }

            set
            {
                _birthday = value;
            }
        }

        public string number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        public string address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }

        public string issue
        {
            get
            {
                return _issue;
            }

            set
            {
                _issue = value;
            }
        }

        public string enable_time
        {
            get
            {
                return _enable_time;
            }

            set
            {
                _enable_time = value;
            }
        }

        public string photo_id
        {
            get
            {
                return _photo_id;
            }

            set
            {
                _photo_id = value;
            }
        }

        #endregion

        #region 方法

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion
    }
}
