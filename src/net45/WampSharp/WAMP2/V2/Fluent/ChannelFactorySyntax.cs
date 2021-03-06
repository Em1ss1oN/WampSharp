using System.ComponentModel;
using WampSharp.Core.Listener;
using WampSharp.V2.Binding;

namespace WampSharp.V2.Fluent
{
    public abstract class ChannelFactorySyntax
    {
        public interface ISyntaxState
        {
            [EditorBrowsable(EditorBrowsableState.Advanced)]
            ChannelState State { get; }
        }

        public interface IRealmSyntax : ISyntaxState
        {
        }

        public interface ITransportSyntax : ISyntaxState
        {
        }

        public interface ISerializationSyntax : ISyntaxState, IBuildableSyntax
        {
        }

        public interface IAuthenticationSyntax : ISyntaxState, IBuildableSyntax
        {
        }

        public interface IBuildableSyntax
        {
            IWampChannel Build();
        }
    }
}