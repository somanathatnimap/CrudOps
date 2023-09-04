using System;
using System.Reflection;

namespace Crud_using_Api_and_stored_procedure.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}