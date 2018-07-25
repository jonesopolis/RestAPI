using System.Collections.Generic;

namespace AG.Utilities
{
    public class ResponseMeta
    {
        protected ResponseMeta() { }

        public static ResponseMeta CreateSuccess()
        {
            return new ResponseMeta
            {
                Success = true,
                Errors = null
            };
        }

        public static ResponseMeta CreateFailure(ResponseFailureType failureType)
        {
            return new ResponseMeta
            {
                Success = false,
                Errors = new List<string>(),
                FailureType = failureType              
            };
        }

        public static ResponseMeta CreateFailure(string error)
        {
            return new ResponseMeta
            {
                Success = false,
                Errors = new[] { error },
                FailureType = ResponseFailureType.Other
            };
        }

        public static ResponseMeta CreateFailure(IEnumerable<string> errors)
        {
            return new ResponseMeta
            {
                Success = false,
                Errors = errors,
                FailureType = ResponseFailureType.Other
            };
        }

        public static ResponseMeta CreateFailure(ResponseFailureType failureType, IEnumerable<string> errors)
        {
            return new ResponseMeta
            {
                Success = false,
                Errors = errors,
                FailureType = failureType
            };
        }

        public bool Success { get; protected set; }
        public ResponseFailureType FailureType { get; protected set; }
        public IEnumerable<string> Errors { get; protected set; }
    }

    public class ResponseMeta<T> : ResponseMeta
    {
        protected ResponseMeta() { }

        public static ResponseMeta<T> CreateSuccess(T item)
        {
            return new ResponseMeta<T>
            {
                Success = true,
                Item = item,
                Errors = null
            };
        }

        public static ResponseMeta<T> CreateFailure(ResponseFailureType failureType)
        {
            return new ResponseMeta<T>
            {
                Success = false,
                Errors = new List<string>(),
                FailureType = failureType
            };
        }

        public new static ResponseMeta<T> CreateFailure(string error)
        {
            return new ResponseMeta<T>
            {
                Success = false,
                Item = default(T),
                Errors = new[] { error },
                FailureType = ResponseFailureType.Other
            };
        }
        
        public new static ResponseMeta<T> CreateFailure(IEnumerable<string> errors)
        {
            return new ResponseMeta<T>
            {
                Success = false,
                Item = default(T),
                Errors = errors,
                FailureType = ResponseFailureType.Other
            };
        }

        public static ResponseMeta<T> CreateFailure(ResponseFailureType failureType, IEnumerable<string> errors)
        {
            return new ResponseMeta<T>
            {
                Success = false,
                Errors = errors,
                FailureType = failureType
            };
        }

        public T Item { get; internal set; }
    }
}
