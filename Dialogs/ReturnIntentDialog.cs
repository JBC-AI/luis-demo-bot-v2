using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;

namespace Microsoft.BotBuilderSamples
{
    public class ReturnIntentDialog : CancelAndHelpDialog
    {
        public ReturnIntentDialog()
            : base(nameof(ReturnIntentDialog))
        {
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));
            AddDialog(new DateResolverDialog());
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                FinalStepAsync,
            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var returnIntents = (ReturnIntents)stepContext.Options;

            return await stepContext.EndDialogAsync(returnIntents);

            //if ((bool)stepContext.Result == true)
            //{
            //    var returnIntents = (ReturnIntents)stepContext.Options;

            //    return await stepContext.EndDialogAsync(returnIntents);
            //}
            //else
            //{
            //    return await stepContext.EndDialogAsync(null);
            //}
        }
    }
}
