#include <JavaScriptCore/JavaScriptCore.h>

NSString* JavaScriptCore_CreateNSString(const char* string)
{
    return [NSString stringWithUTF8String: string ? string : ""];
}

char* JavaScriptCore_MakeStringCopy(const char* string)
{
    if (string == NULL) return NULL;
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

extern "C"
{
    JSContext *context;

    void _EvaluateScript(const char* text)
    {
        context = [[JSContext alloc] init];
        [context evaluateScript: JavaScriptCore_CreateNSString(text)];
    }

    char *_CallFunction1(const char* methodName)
    {
        JSValue *bench = [context objectForKeyedSubscript: @"bench"];
        JSValue *main = [bench objectForKeyedSubscript: @"Main"];
        JSValue *function = [main objectForKeyedSubscript: JavaScriptCore_CreateNSString(methodName)];
        JSValue *result = [function callWithArguments: @[]];
        NSString *resultText = [result toString];
        return JavaScriptCore_MakeStringCopy([resultText UTF8String]);
    }

    char *_CallFunction2(const char* methodName, int args0)
    {
        JSValue *jsValueArgs0 = [JSValue valueWithInt32: args0 inContext: context];

        JSValue *bench = [context objectForKeyedSubscript: @"bench"];
        JSValue *main = [bench objectForKeyedSubscript: @"Main"];
        JSValue *function = [main objectForKeyedSubscript: JavaScriptCore_CreateNSString(methodName)];
        JSValue *result = [function callWithArguments: @[jsValueArgs0]];
        NSString *resultText = [result toString];
        return JavaScriptCore_MakeStringCopy([resultText UTF8String]);
    }
}
