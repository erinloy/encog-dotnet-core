﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.Neural.NeuralData.Market.DB.Loader.YahooFinance;
using Encog.Neural.Data.Market.DB;

namespace Encog.Neural.NeuralData.Market.DB
{
    [Serializable]
    public class StoredMarketData: StoredData
    {
        private double high;
        private double low;
        private double open;
        private double close;
        private double adjustedHigh;
        private double adjustedLow;
        private double adjustedOpen;
        private double adjustedClose;
        private ulong volume;

        /// <summary>
        /// The data that was collection for the sample date.
        /// </summary>
        private IDictionary<MarketDataType, object> data;

        public override String ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("EndOfDay: date=");
            result.Append(Date);
            result.Append(", Close=");
            result.Append(close);
            return result.ToString();
        }

        public void Adjust(double adjust)
        {
            this.adjustedHigh = this.high * adjust;
            this.adjustedLow = this.low * adjust;
            this.adjustedOpen = this.open * adjust;
            this.adjustedClose = this.close * adjust;
        }

        public double High
        {
            get
            {
                return this.high;
            }
            set
            {
                this.high = value;
            }
        }

        public double Low
        {
            get
            {
                return this.low;
            }
            set
            {
                this.low = value;
            }
        }

        public double Open
        {
            get
            {
                return this.open;
            }
            set
            {
                this.open = value;
            }
        }

        public double Close
        {
            get
            {
                return this.close;
            }
            set
            {
                this.close = value;
            }
        }

        public double AdjustedHigh
        {
            get
            {
                return this.adjustedHigh;
            }
        }

        public double AdjustedLow
        {
            get
            {
                return this.adjustedLow;
            }
        }

        public double AdjustedOpen
        {
            get
            {
                return this.open;
            }
        }

        public double AdjustedClose
        {
            get
            {
                return this.close;
            }
        }

        public ulong Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                this.volume = value;
            }
        }

        /// <summary>
        /// Set the specified type of data.
        /// </summary>
        /// <param name="t">The type of data to set.</param>
        /// <param name="d">The value to set.</param>
        public void SetData(MarketDataType t, double d)
        {
            switch (t)
            {
                case MarketDataType.OPEN:
                    Open = d;
                    break;
                case MarketDataType.CLOSE:
                    Close = d;
                    break;
                case MarketDataType.VOLUME:
                    Volume = (ulong)d;
                    break;
                case MarketDataType.HIGH:
                    High = d;
                    break;
                case MarketDataType.LOW:
                    Low = d;
                    break;
                default:
                    this.data[t] = d;
                    break;
            }
        }

        /// <summary>
        /// Set the specified type of data.
        /// </summary>
        /// <param name="t">The type of data to set.</param>
        /// <param name="d">The value to set.</param>
        public void SetData(MarketDataType t, long d)
        {
            switch (t)
            {
                case MarketDataType.OPEN:
                    Open = d;
                    break;
                case MarketDataType.CLOSE:
                    Close = d;
                    break;
                case MarketDataType.VOLUME:
                    Volume = (ulong)d;
                    break;
                case MarketDataType.HIGH:
                    High = d;
                    break;
                case MarketDataType.LOW:
                    Low = d;
                    break;
                default:
                    this.data[t] = d;
                    break;
            }

        }

        /// <summary>
        /// Get the specified data type.
        /// </summary>
        /// <param name="t">The type of data to get.</param>
        /// <returns>The value.</returns>
        public double GetDataDouble(MarketDataType t)
        {
            switch (t)
            {
                case MarketDataType.OPEN:
                    return (double)Open;
                case MarketDataType.CLOSE:
                    return (double)Close;
                case MarketDataType.VOLUME:
                    return (double)Volume;
                case MarketDataType.HIGH:
                    return (double)High;
                case MarketDataType.LOW:
                    return (double)Low;
                case MarketDataType.ADJUSTED_OPEN:
                    return (double)AdjustedOpen;
                case MarketDataType.ADJUSTED_CLOSE:
                    return (double)AdjustedClose;
                case MarketDataType.ADJUSTED_HIGH:
                    return (double)AdjustedHigh;
                case MarketDataType.ADJUSTED_LOW:
                    return (double)AdjustedLow;
                default:
                    return (double)this.data[t];
            }            
        }

        /// <summary>
        /// Get the specified data type.
        /// </summary>
        /// <param name="t">The type of data to get.</param>
        /// <returns>The value.</returns>
        public long GetDataLong(MarketDataType t)
        {
            switch (t)
            {
                case MarketDataType.OPEN:
                    return (long)Open;
                case MarketDataType.CLOSE:
                    return (long)Close;
                case MarketDataType.VOLUME:
                    return (long)Volume;
                case MarketDataType.HIGH:
                    return (long)High;
                case MarketDataType.LOW:
                    return (long)Low;
                case MarketDataType.ADJUSTED_OPEN:
                    return (long)AdjustedOpen;
                case MarketDataType.ADJUSTED_CLOSE:
                    return (long)AdjustedClose;
                case MarketDataType.ADJUSTED_HIGH:
                    return (long)AdjustedHigh;
                case MarketDataType.ADJUSTED_LOW:
                    return (long)AdjustedLow;
                default:
                    return (long)this.data[t];
            }
        }
    }
}